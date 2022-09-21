using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;//constructor injection
        ICategoryService _categoryService;


        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }//end injection

        [ValidationAspect(typeof(ProductValidator))]//bu bir attribute
        public IResult Add(Product product)
        {
            //businnes code=iş ihtiyaçlarına uygunluk
            //validation code=nesnenin yapısal olarak uygunluğunu kontrol eden yapı
            //birbirleri yerine koyma!
            IResult result = BusinessRules.Run(CheckIfCategoryProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExits(product.ProductName),
                CheckIfCategoryLimitExceeded());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);//constr a hemen bilgi verilip işlem burada oluşturulup yapılır
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfCategoryProductCountOfCategoryCorrect(int categoryId)
        {
            //bir kategoride en fazla 10 ürün olabilir kod örneği
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExits(string productName)
        {
            //aynı isimde ürün eklenemez kod örneği
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();//an sistem linq kullanır var mı diye sorar
            //any kullanmadan result!=null diyerek kontrol edilebilir.
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExits);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceeded()
        {
            //eğer mevcut kategori sayısı 15'i geçtise sisteme ürün eklenemez
            var result = _categoryService.GetAll();//an sistem linq kullanır var mı diye sorar
            //any kullanmadan result!=null diyerek kontrol edilebilir.
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}

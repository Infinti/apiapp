using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        #region Ver1.0
        //List<Product> GetAll();//entity referans olarak eklendi// ver.1.0 idi
        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);
        //List<Product> GetAllByCatagory(int categoryId); 
        #endregion
        List<ProductDetailDto> GetProductDetails();
    }
}

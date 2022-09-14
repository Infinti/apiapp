﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;//similasyon için veri varmış gibi, '_' kullanılırsa global değişken (final)
        public InMemoryProductDal()
        {
            _products=new List<Product>
            {
                new Product{ProductId=1, ProductName="Bardak",CategoryId=1, UnitPrice=15, UnitsInStock=10},
                new Product{ProductId=2, ProductName="Kamera",CategoryId=1, UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, ProductName="Telefon",CategoryId=2, UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, ProductName="Klavye",CategoryId=2, UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, ProductName="Fare",CategoryId=2, UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Product productToDelete=null; //bu eski düzen --=> Lambda
            //foreach (var p in _products)
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);//singleorDefault aynı foreach gibi id aramalarında önemli
            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()//businesse gitcek bu
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCatagory(int categoryId)
        {
            return _products.Where(p => p.CategoryId==categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName=product.ProductName;//geleni bulduğuna ata (gelen product) (bulunan productToUpdate)
            productToUpdate.CategoryId=product.CategoryId;
            productToUpdate.UnitPrice=product.UnitPrice;
            productToUpdate.UnitsInStock=product.UnitsInStock;
            
        }
    }
}

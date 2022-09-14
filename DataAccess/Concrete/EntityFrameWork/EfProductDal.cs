using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context=new NorthwindContext())//performans artışı GB gelip çöpleri toplar bellek temizlenir
            {
                var addedEntity = context.Entry(entity);//eklemeyi eşleştir
                addedEntity.State=EntityState.Added;//durumu ekle
                context.SaveChanges();//kaydet
            }
        }


        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())//performans artışı GB gelip çöpleri toplar bellek temizlenir
            {
                var deletedEntity = context.Entry(entity);//eklemeyi eşleştir
                deletedEntity.State = EntityState.Deleted;//durumu sil
                context.SaveChanges();//kaydet
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();//filtreleme örneği
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())//performans artışı GB gelip çöpleri toplar bellek temizlenir
            {
                var updatedEntity = context.Entry(entity);//eklemeyi eşleştir
                updatedEntity.State = EntityState.Modified;//durumu sil
                context.SaveChanges();//kaydet
            }
        }
    }
}

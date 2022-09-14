using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic constraint-- kıstlama 
    //class referans tip
    //IEntity tipi veya onu implement eden 
    //new lenebilir yani oluşturulabilir soyut olmayan, böylelikle IEntity yani soyut bir nesne çağırılmaz
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//ürünleri filtrelemee sağlıyor
        T Get(Expression<Func<T, bool>> filter); 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

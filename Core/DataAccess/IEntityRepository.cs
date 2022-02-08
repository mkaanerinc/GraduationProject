using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // Her Entity için temel database işlemleri ortak  olduğu için bir interface'te yazıldı.
    // Burada Generic verirken sınırlama sırasında;
    // class => Reference Type
    // IEntity => veritabanı referansı olan bir class
    // new() => IEntity koyulamaması için eklendi.
    // Her projede aynı olacağı için Core katmanına eklendi.

    public interface IEntityRepository<T>
        where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        T Find(int entityId);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}

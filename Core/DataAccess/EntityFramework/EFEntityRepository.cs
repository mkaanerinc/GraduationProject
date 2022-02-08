using Core.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    // Burada Generic verirken sınırlama sırasında;
    // DbContext => TContext'in DbContext'dan  türeyen bir sınıf olma koşulu koyuldu.
    // IDisposable Pattern İmplementation of CSharp. Using bloğundan çıkıldığında Garbage Collector'a geçer ve Dispose edilir.
    // Bunu DbContext sınıfının IDisposable'dan türediği için yapabildik.
    // Her projede aynı olacağı için Core katmanına eklendi.

    public class EFEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(predicate);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            using (TContext context = new TContext())
            {
                return predicate == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(predicate).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

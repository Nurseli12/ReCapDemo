using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext conn = new())
            {
                var added = conn.Entry(entity);
                added.State = EntityState.Added;
                conn.SaveChanges();
            }
        }

        public void Deleted(TEntity entity)
        {
            using (TContext conn = new TContext())
            {
                var deleted = conn.Entry(entity);
                deleted.State = EntityState.Deleted;
                conn.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext conn = new TContext())
            {
                return conn.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext conn = new TContext())
            {
                return filter == null ? conn.Set<TEntity>().ToList() :
                     conn.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext conn = new TContext())
            {
                var updated = conn.Entry(entity);
                updated.State = EntityState.Modified;
                conn.SaveChanges();
            }
        }
    }
}

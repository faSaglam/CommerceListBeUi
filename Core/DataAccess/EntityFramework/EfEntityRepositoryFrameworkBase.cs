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
    public class EfEntityRepositoryFrameworkBase<TEntity, TContext> : IEntityReposityory<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new() //entityframeworkcore paketinden geldi. İçerik Database türünde olmalı
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())//garbage collector'ün çalışması için using yazıldı
            {
                var addEntity = context.Entry(entity);
                //Entry entity'leri getirir
                //giriş ve değişiklik izlemeye yarar
                addEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using(TContext context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updateEntry = context.Entry(entity);
                updateEntry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        //public TEntity Get(Expression<Func<TEntity, bool>> filter)
        //{
        //    using(TContext context = new TContext())
        //    {
        //        //return context.Set<TEntity>().SingleOrDefault(filter);//aranan bir entityi döndürdük
        //        return context.Set<TEntity>().Where(filter).MyInclude().SingleOrDefault();
        //    }
        //}

        //public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        //{
        //    using(TContext context = new TContext())
        //    {
        //      if(filter == null)
        //        {
        //            return context.Set<TEntity>().ToList();
        //        }
        //       return context.Set<TEntity>().Where(filter).ToList();
        
        //    }
        //}

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            using(TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(expression);
            }
         
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            using(TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).MyInclude(includes).SingleOrDefault();
            }
     
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            using (TContext context = new TContext())
            {
                if (filter == null)
                {
                    return context.Set<TEntity>().MyInclude(includes).ToList();
                }
                else
                {
                    return context.Set<TEntity>().Where(filter).MyInclude(includes).ToList();
                }
            }
     
        }
    }
}

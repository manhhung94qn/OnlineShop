using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private OnlineShopDbContext dbContext;

        protected RepositoryBase(OnlineShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region Implement
        public virtual TEntity Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Attach(entity);
            dbContext.Set<TEntity>().Update(entity);
            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Attach(entity);
            dbContext.Set<TEntity>().Remove(entity);
        }
        public virtual void Delete(int id)
        {
            var entity = dbContext.Set<TEntity>().Find(id);
            dbContext.Set<TEntity>().Attach(entity);
            dbContext.Set<TEntity>().Remove(entity);
        }
        public virtual void DeleteMulti(Expression<Func<TEntity, bool>> where)
        {
            List<TEntity> objects = dbContext.Set<TEntity>().Where<TEntity>(where).ToList();
            foreach (TEntity obj in objects) {
                dbContext.Set<TEntity>().Attach(obj);
                dbContext.Set<TEntity>().Remove(obj);
            }
        }

        public virtual TEntity GetSingleById(long id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public virtual List<TEntity> GetMany(Expression<Func<TEntity, bool>> where, string includes)
        {
            return dbContext.Set<TEntity>().Where(where).ToList();
        }


        public virtual int Count(Expression<Func<TEntity, bool>> where)
        {
            return dbContext.Set<TEntity>().Count(where);
        }

        public List<TEntity> GetAll(string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<TEntity>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.ToList();
            }

            return dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetSingleByCondition(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<TEntity>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return dbContext.Set<TEntity>().FirstOrDefault(expression);
        }

        public virtual List<TEntity> GetMulti(Expression<Func<TEntity, bool>> predicate, string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<TEntity>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<TEntity>(predicate).ToList<TEntity>();
            }

            return dbContext.Set<TEntity>().Where<TEntity>(predicate).ToList<TEntity>();
        }

        //public virtual List<TEntity> GetMultiPaging(Expression<Func<TEntity, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null)
        //{
        //    int skipCount = index * size;
        //    List<TEntity> _resetSet;

        //    //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
        //    if (includes != null && includes.Count() > 0)
        //    {
        //        var query = dbContext.Set<TEntity>().Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //            query = query.Include(include);
        //        _resetSet = predicate != null ? query.Where<TEntity>(predicate).ToList() : query.ToList();
        //    }
        //    else
        //    {
        //        _resetSet = predicate != null ? dbContext.Set<TEntity>().Where<TEntity>(predicate).ToList() : dbContext.Set<TEntity>().ToList();
        //    }
        //    total = _resetSet.Count();
        //    _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
        //    return _resetSet.ToList();
        //}

        public bool CheckContains(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Count<TEntity>(predicate) > 0;
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        // Marks an entity as new
        TEntity Add(TEntity entity);

        // Marks an entity as modified
        TEntity Update(TEntity entity);

        // Marks an entity to be removed
        void Delete(TEntity entity);

        void Delete(int id);

        //Delete multi records
        void DeleteMulti(Expression<Func<TEntity, bool>> where);

        // Get an entity by int id
        TEntity GetSingleById(long id);

        TEntity GetSingleByCondition(Expression<Func<TEntity, bool>> expression, string[] includes = null);

        List<TEntity> GetAll(string[] includes = null);

        List<TEntity> GetMulti(Expression<Func<TEntity, bool>> predicate, string[] includes = null);

        //List<TEntity> GetMultiPaging(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        int Count(Expression<Func<TEntity, bool>> where);

        bool CheckContains(Expression<Func<TEntity, bool>> predicate);
    }
}

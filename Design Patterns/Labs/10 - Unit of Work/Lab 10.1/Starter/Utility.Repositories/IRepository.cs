using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Wincubate.UnitOfWorkExamples.Utility.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

        void Add(TEntity product);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity product);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}

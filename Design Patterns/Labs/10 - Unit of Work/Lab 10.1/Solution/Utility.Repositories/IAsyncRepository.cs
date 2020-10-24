using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Wincubate.UnitOfWorkExamples.Utility.Repositories
{
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> filter, 
            CancellationToken cancellationToken = default
        );

        void Add(TEntity product);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity product);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}

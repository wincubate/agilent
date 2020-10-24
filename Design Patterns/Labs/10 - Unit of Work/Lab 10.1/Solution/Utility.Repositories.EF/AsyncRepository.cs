using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Wincubate.UnitOfWorkExamples.Utility.Repositories.EF
{
    public class AsyncRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    {
        protected DbContext Context { get; }

        public AsyncRepository(DbContext context)
        {
            Context = context;
        }

        public Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken) =>
            Context.Set<TEntity>()
                .FindAsync(id, cancellationToken)
                .AsTask()
                ;

        public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken) =>
            Context.Set<TEntity>()
                .ToListAsync(cancellationToken)
                .ContinueWith(t => t.Result.AsEnumerable())
                ;

        public Task<IEnumerable<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> filter, 
            CancellationToken cancellationToken
        ) =>
            Context.Set<TEntity>()
                .Where(filter)
                .ToListAsync(cancellationToken)
                .ContinueWith( t => t.Result.AsEnumerable() )
                ;

        public void Add(TEntity entity) =>
            Context.Set<TEntity>().Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) =>
           Context.Set<TEntity>().AddRange(entities);

        public void Remove(TEntity entity) =>
            Context.Set<TEntity>().Remove(entity);
        public void RemoveRange(IEnumerable<TEntity> entities) =>
           Context.Set<TEntity>().RemoveRange(entities);
    }
}

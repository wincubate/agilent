using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Wincubate.UnitOfWorkExamples.Data;
using Wincubate.UnitOfWorkExamples.Utility.Repositories;

namespace Wincubate.UnitOfWorkExamples
{
    interface IAsyncProductRepository : IAsyncRepository<Product>
    {
        Task<IEnumerable<Product>> GetForCategoryAsync(
            Category? category, 
            CancellationToken cancellationToken = default
        );
        Task<IEnumerable<Product>> GetAllWithCommentsAsync(CancellationToken cancellationToken = default);
    }
}
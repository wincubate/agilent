using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wincubate.UnitOfWorkExamples.Data;
using Wincubate.UnitOfWorkExamples.Data.EF;
using Wincubate.UnitOfWorkExamples.Utility.Repositories.EF;

namespace Wincubate.UnitOfWorkExamples
{
    class AsyncProductRepository : AsyncRepository<Product>, IAsyncProductRepository
    {
        protected ProductsContext ProductsContext => Context as ProductsContext;

        public AsyncProductRepository(ProductsContext context) : base(context)
        {
        }

        public Task<IEnumerable<Product>> GetForCategoryAsync(Category? category, CancellationToken cancellationToken) =>
            ProductsContext.Products
                .Where(product => product.Category == category)
                .ToListAsync(cancellationToken)
                .ContinueWith( t => t.Result.AsEnumerable() )
                ;

        public Task<IEnumerable<Product>> GetAllWithCommentsAsync(CancellationToken cancellationToken) =>
            ProductsContext.Products
                .Include(product => product.Comments)
                .Where(product => product.Comments.Any())
                .ToListAsync(cancellationToken)
                .ContinueWith( t => t.Result.AsEnumerable() )
                ;
    }
}
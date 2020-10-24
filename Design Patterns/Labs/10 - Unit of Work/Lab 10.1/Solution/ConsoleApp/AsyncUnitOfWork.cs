using System.Threading.Tasks;
using Wincubate.UnitOfWorkExamples.Data.EF;

namespace Wincubate.UnitOfWorkExamples
{
    class AsyncUnitOfWork : IAsyncUnitOfWork
    {
        public IAsyncProductRepository Products { get; }
        public IAsyncCommentRepository Comments { get; }

        private readonly ProductsContext _context;

        public AsyncUnitOfWork( ProductsContext context )
        {
            _context = context;

            Products = new AsyncProductRepository(context);
            Comments = new AsyncCommentRepository(context);
        }

        public Task CompleteAsync() => _context.SaveChangesAsync();

        public ValueTask DisposeAsync() => _context.DisposeAsync();
    }
}
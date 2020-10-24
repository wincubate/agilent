using Wincubate.UnitOfWorkExamples.Data.EF;

namespace Wincubate.UnitOfWorkExamples
{
    class UnitOfWork : IUnitOfWork
    {
        public IProductRepository Products { get; }
        public ICommentRepository Comments { get; }

        private readonly ProductsContext _context;

        public UnitOfWork( ProductsContext context )
        {
            _context = context;

            Products = new ProductRepository(context);
            Comments = new CommentRepository(context);
        }

        public void Complete() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
using Wincubate.UnitOfWorkExamples.Data;
using Wincubate.UnitOfWorkExamples.Data.EF;
using Wincubate.UnitOfWorkExamples.Utility.Repositories.EF;

namespace Wincubate.UnitOfWorkExamples
{
    class AsyncCommentRepository : AsyncRepository<Comment>, IAsyncCommentRepository
    {
        protected ProductsContext ProductsContext => Context as ProductsContext;

        public AsyncCommentRepository(ProductsContext context) : base(context)
        {
        }
    }
}
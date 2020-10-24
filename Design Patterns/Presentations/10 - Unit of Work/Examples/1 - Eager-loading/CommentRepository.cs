using Wincubate.UnitOfWorkExamples.Data;
using Wincubate.UnitOfWorkExamples.Data.EF;
using Wincubate.UnitOfWorkExamples.Utility.Repositories.EF;

namespace Wincubate.UnitOfWorkExamples
{
    class CommentRepository : Repository<Comment>, ICommentRepository
    {
        protected ProductsContext ProductsContext => Context as ProductsContext;

        public CommentRepository(ProductsContext context) : base(context)
        {
        }
    }
}
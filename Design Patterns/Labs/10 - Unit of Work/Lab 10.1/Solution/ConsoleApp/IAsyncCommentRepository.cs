using Wincubate.UnitOfWorkExamples.Data;
using Wincubate.UnitOfWorkExamples.Utility.Repositories;

namespace Wincubate.UnitOfWorkExamples
{
    interface IAsyncCommentRepository : IAsyncRepository<Comment>
    {
    }
}
using System;
using System.Threading.Tasks;

namespace Wincubate.UnitOfWorkExamples
{
    interface IAsyncUnitOfWork : IAsyncDisposable
    {
        public IAsyncProductRepository Products { get; }
        public IAsyncCommentRepository Comments { get; }

        Task CompleteAsync();
    }
}
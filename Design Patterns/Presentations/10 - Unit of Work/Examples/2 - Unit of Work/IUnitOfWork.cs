using System;

namespace Wincubate.UnitOfWorkExamples
{
    interface IUnitOfWork : IDisposable
    {
        public IProductRepository Products { get; }
        public ICommentRepository Comments { get; }

        void Complete();
    }
}
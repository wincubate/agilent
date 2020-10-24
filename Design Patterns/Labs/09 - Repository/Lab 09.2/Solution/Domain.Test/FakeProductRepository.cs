using Wincubate.RepositoryLabs.Domain.Interfaces;

namespace Wincubate.RepositoryLabs.Domain.Test
{
    class FakeProductRepository : FakeRepository<Product>, IProductRepository
    {
        public FakeProductRepository(params Product[] elements) : base(elements)
        {
        }
    }
}

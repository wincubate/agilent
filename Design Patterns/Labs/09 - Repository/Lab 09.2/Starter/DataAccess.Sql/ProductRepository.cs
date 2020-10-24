using Wincubate.RepositoryLabs.Domain.Interfaces;

namespace Wincubate.RepositoryLabs.DataAccess.Sql
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        protected ProductsContext ProductsContext => Context as ProductsContext;

        public ProductRepository(ProductsContext context) : base(context)
        {
        }
    }
}

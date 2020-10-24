using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Wincubate.UnitOfWorkExamples.Data;
using Wincubate.UnitOfWorkExamples.Data.EF;
using Wincubate.UnitOfWorkExamples.Utility.Repositories.EF;

namespace Wincubate.UnitOfWorkExamples
{
    class ProductRepository : Repository<Product>, IProductRepository
    {
        protected ProductsContext ProductsContext => Context as ProductsContext;

        public ProductRepository(ProductsContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetForCategory(Category? category) =>
            ProductsContext.Products
                .Where(product => product.Category == category)
                .ToList()
                ;

        public IEnumerable<Product> GetAllWithComments() =>
            ProductsContext.Products
                .Include(product => product.Comments)
                .Where(product => product.Comments.Any())
                .ToList()
                ;
    }
}
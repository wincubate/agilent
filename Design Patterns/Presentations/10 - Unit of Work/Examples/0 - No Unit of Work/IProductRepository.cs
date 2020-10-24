using System.Collections.Generic;
using Wincubate.UnitOfWorkExamples.Data;
using Wincubate.UnitOfWorkExamples.Utility.Repositories;

namespace Wincubate.UnitOfWorkExamples
{
    interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetForCategory(Category? category);
    }
}
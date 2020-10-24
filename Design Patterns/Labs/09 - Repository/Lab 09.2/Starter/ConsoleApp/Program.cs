using System;
using System.Collections.Generic;
using Wincubate.RepositoryLabs.DataAccess.Sql;
using Wincubate.RepositoryLabs.Domain;
using Wincubate.RepositoryLabs.Domain.Interfaces;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductRepository repository = new ProductRepository(new ProductsContext());
            ProductService service = new ProductService(repository);

            // Business logic
            IDictionary<Category?,int> query = service.ComputeGroupCounts();

            foreach (var categoryLine in query)
            {
                Console.WriteLine($"{categoryLine.Key}: {categoryLine.Value}");
            }
        }
    }
}

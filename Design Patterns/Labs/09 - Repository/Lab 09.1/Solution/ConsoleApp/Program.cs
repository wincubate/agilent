using System;
using Wincubate.RepositoryLabs.DataAccess.Sql;
using Wincubate.RepositoryLabs.Domain.Interfaces;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Product> repository = new ProductRepository(new ProductsContext());
            var query = repository.GetAll();

            foreach (var product in query)
            {
                Console.WriteLine(product);
            }
        }
    }
}

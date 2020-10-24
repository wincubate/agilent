using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wincubate.UnitOfWorkExamples.Data;
using Wincubate.UnitOfWorkExamples.Data.EF;

namespace Wincubate.UnitOfWorkExamples
{
    class Program
    {
        static async Task Main( string[] args )
        {
            await using IAsyncUnitOfWork unitOfWork = new AsyncUnitOfWork(new ProductsContext());

            // Reading comments
            IEnumerable<Product> query = await unitOfWork.Products.GetAllWithCommentsAsync();
            foreach (var product in query)
            {
                Console.WriteLine(product);

                foreach (var comment in product.Comments)
                {
                    Console.WriteLine($"\t{comment.Description}");
                }
            }

            // Writing comments
            Product newProduct = new Product
            {
                Category = Category.Hardware,
                Manufacturer = "Oculus",
                Name = "Quest 2"
            };

            Comment newComment = new Comment
            {
                Product = newProduct,
                Description = "Just released"
            };

            unitOfWork.Products.Add(newProduct);
            unitOfWork.Comments.Add(newComment);
            await unitOfWork.CompleteAsync();
        }
    }
}
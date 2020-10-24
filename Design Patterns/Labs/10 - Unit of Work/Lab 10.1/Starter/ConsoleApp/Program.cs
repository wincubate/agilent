using System;
using System.Collections.Generic;
using Wincubate.UnitOfWorkExamples.Data;
using Wincubate.UnitOfWorkExamples.Data.EF;

namespace Wincubate.UnitOfWorkExamples
{
    class Program
    {
        static void Main( string[] args )
        {
            using IUnitOfWork unitOfWork = new UnitOfWork(new ProductsContext());

            // Reading comments
            IEnumerable<Product> query = unitOfWork.Products.GetAllWithComments();
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
            unitOfWork.Complete();
        }
    }
}
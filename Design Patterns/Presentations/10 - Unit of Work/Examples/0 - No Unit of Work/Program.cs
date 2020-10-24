using System;
using System.Collections.Generic;
using System.Linq;
using Wincubate.UnitOfWorkExamples.Data;
using Wincubate.UnitOfWorkExamples.Data.EF;
using Wincubate.UnitOfWorkExamples.Utility.Repositories;

namespace Wincubate.UnitOfWorkExamples
{
    class Program
    {
        static void Main( string[] args )
        {
            IProductRepository productRepository = new ProductRepository(new ProductsContext());
            ICommentRepository commentRepository = new CommentRepository(new ProductsContext());

            // Reading comments
            IEnumerable<Product> query = productRepository.Find(p => p.Comments.Any());
            foreach (var product in query)
            {
                Console.WriteLine(product);

                var comments = commentRepository.Find(n => n.Product.Id == product.Id);
                foreach (var comment in comments)
                {
                    Console.WriteLine($"\t{comment.Description}");
                }
            }

            //// Writing comments
            //Product newProduct = new Product
            //{
            //    Category = Category.Hardware,
            //    Manufacturer = "Oculus",
            //    Name = "Quest 2"
            //};

            //Comment comment = new Comment
            //{
            //    Product = newProduct,
            //    Description = "Just released"
            //};

            //productRepository.Add(newProduct);
            //productRepository.Commit(); // <-- Does not exist, but...

            //commentRepository.Add(comment);
            //notesRepository.Commit(); // <-- Does not exist, but...
        }
    }
}
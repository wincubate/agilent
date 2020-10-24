using System;
using System.Collections.Generic;
using WebShop;

namespace Client
{
    class Program
    {
        static void Main( string[] args )
        {
            using (CachingProductStorage storage = new CachingProductStorage(new ProductStorage()))
            {
                //IEnumerable<Product> all = storage.GetAll();
                //IEnumerable<Product> all2 = storage.GetAll();

                Product p0 = storage.GetById(1);
                Console.WriteLine(p0);
                Product p1 = storage.GetById(1);
                Console.WriteLine(p1);
                Product p2 = storage.GetById(3);
                Console.WriteLine(p2);
                Product p3 = storage.GetById(1);
                Console.WriteLine(p3);
                Product p4 = storage.GetById(1);
                Console.WriteLine(p4);
                Product p5 = storage.GetById(1);
                Console.WriteLine(p5);
                Product p6 = storage.GetById(3);
                Console.WriteLine(p6);
            }
        }
    }
}

using System.Collections.Generic;

namespace WebShop
{
    public interface IProductStorage
    {
        Product GetById( int id );
        IEnumerable<Product> GetAll();
        void Add( Product product );
    }
}

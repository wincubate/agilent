using System.Collections.Generic;

namespace Wincubate.ProxyExamples.WebShop
{
    public interface IProductStorage
    {
        Product GetById( int id );
        IEnumerable<Product> GetAll();
        void Add( Product product );
    }
}

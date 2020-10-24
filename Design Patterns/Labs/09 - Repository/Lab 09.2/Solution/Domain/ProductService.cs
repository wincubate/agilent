using System;
using System.Collections.Generic;
using System.Linq;
using Wincubate.RepositoryLabs.Domain.Interfaces;

namespace Wincubate.RepositoryLabs.Domain
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
        }

        public IDictionary<Category?,int> ComputeGroupCounts() =>
            _productRepository.GetAll()
                .GroupBy(product => product.Category)
                .ToDictionary( g => g.Key, g => g.Count() )
                ;
    }
}
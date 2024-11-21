using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var product = await _productRepository.GetById(id);

            if (product == null) { throw new KeyNotFoundException("Product not found."); }

            return product;
        }
        public async Task<IEnumerable<Product>> GetProductsByIds(IEnumerable<Guid> ids)
        {
            var products = await _productRepository.GetByIds(ids);

            if (products == null) { throw new KeyNotFoundException("Products not found."); }

            return products;
        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await _productRepository.GetAll();

        public async Task UpdateProduct(Product product)
        {
            await _productRepository.Update(product);
        }
    }
}

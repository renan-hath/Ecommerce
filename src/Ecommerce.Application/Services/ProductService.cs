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

        public async Task Add(Product product)
        {
            await _productRepository.Add(product);
        }

        public async Task<Product> GetById(Guid id)
        {
            var product = await _productRepository.GetById(id);

            if (product == null) { throw new KeyNotFoundException("Product not found."); }

            return product;
        }

        public async Task<IEnumerable<Product>> GetAll() => await _productRepository.GetAll();

        public async Task Update(Product product)
        {
            await _productRepository.Update(product);
        }

        public async Task Delete(Guid id)
        {
            await _productRepository.Delete(id);
        }
    }
}

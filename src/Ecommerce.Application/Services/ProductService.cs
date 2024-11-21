using Ecommerce.Application.DataTransferObjects;
using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories.Interfaces;

namespace Ecommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Add(ProductDto productDto)
        {
            ValidateStatus(productDto.Status);
            var product = new Product(productDto.Name, productDto.Status);
            await _productRepository.Add(product);

            return product;
        }

        public async Task<Product> GetById(Guid id)
        {
            var product = await _productRepository.GetById(id);

            return product;
        }

        public async Task<IEnumerable<Product>> GetByIds(IEnumerable<Guid> ids)
        {
            var products = await _productRepository.GetByIds(ids);

            if (products == null)
            {
                return Enumerable.Empty<Product>();
            }

            return products;
        }

        public async Task<IEnumerable<Product>> GetAll() => await _productRepository.GetAll();

        public async Task<Product> Update(Guid id, ProductDto productDto)
        {
            ValidateStatus(productDto.Status);
            var updatedProduct = await GetById(id);
            updatedProduct.Name = productDto.Name;
            updatedProduct.Status = productDto.Status;
            await _productRepository.Update(updatedProduct);

            return updatedProduct;
        }

        public async Task Delete(Guid id)
        {
            await _productRepository.Delete(id);
        }

        private void ValidateStatus(string status)
        {
            if (status != "disponível" && status != "indisponível" && status != "reservado")
            {
                throw new InvalidOperationException("Invalid status for product.");
            }
        }
    }
}

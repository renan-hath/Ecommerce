using Ecommerce.Application.DataTransferObjects;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services.Interfaces
{
    public interface IProductService
    {
        public Task<Product> Add(ProductDto productDto);
        public Task<Product> GetById(Guid id);
        public Task<IEnumerable<Product>> GetByIds(IEnumerable<Guid> ids);
        public Task<IEnumerable<Product>> GetAll();
        public Task<Product> Update(Guid id, ProductDto productDto);
        public Task Delete(Guid id);
    }
}

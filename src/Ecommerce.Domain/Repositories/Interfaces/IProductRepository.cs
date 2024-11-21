using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task Add(Product product);
        public Task<Product> GetById(Guid id);
        public Task<IEnumerable<Product>> GetByIds(IEnumerable<Guid> ids);
        public Task<IEnumerable<Product>> GetAll();
        public Task Update(Product product);
        public Task Delete(Guid id);
    }
}

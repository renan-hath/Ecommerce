using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public Task Add(Customer customer);
        public Task<Customer> GetById(Guid id);
        public Task<IEnumerable<Customer>> GetAll();
        public Task Update(Customer customer);
        public Task Delete(Guid id);
    }
}

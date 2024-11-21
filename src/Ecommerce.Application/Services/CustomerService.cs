using Ecommerce.Application.DataTransferObjects;
using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories.Interfaces;

namespace Ecommerce.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Add(CustomerDto customerDto)
        {
            var customer = new Customer(customerDto.Name);
            await _customerRepository.Add(customer);

            return customer;
        }

        public async Task<Customer> GetById(Guid id)
        {
            var customer = await _customerRepository.GetById(id);

            if (customer == null) { throw new KeyNotFoundException("Customer not found."); }

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<Customer> Update(Guid id, CustomerDto customerDto)
        {
            var updatedCustomer = await GetById(id);
            updatedCustomer.Name = customerDto.Name;
            await _customerRepository.Update(updatedCustomer);

            return updatedCustomer;
        }

        public async Task Delete(Guid id)
        {
            await _customerRepository.Delete(id);
        }
    }
}

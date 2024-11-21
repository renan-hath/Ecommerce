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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Add(Customer customer)
        {
            await _customerRepository.Add(customer);
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

        public async Task Update(Customer customer)
        {
            await _customerRepository.Update(customer);
        }

        public async Task Delete(Guid id)
        {
            await _customerRepository.Delete(id);
        }
    }
}

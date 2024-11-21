using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task Add(Customer customer);
        public Task<Customer> GetById(Guid id);
        public Task<IEnumerable<Customer>> GetAll();
        public Task Update(Customer customer);
        public Task Delete(Guid id);
    }
}

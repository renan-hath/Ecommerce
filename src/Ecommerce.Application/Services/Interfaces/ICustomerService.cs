using Ecommerce.Application.DataTransferObjects;
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
        public Task<Customer> Add(CustomerDto customerDto);
        public Task<Customer> GetById(Guid id);
        public Task<IEnumerable<Customer>> GetAll();
        public Task<Customer> Update(Guid id, CustomerDto customerDto);
        public Task Delete(Guid id);
    }
}

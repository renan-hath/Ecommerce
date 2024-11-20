using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EcommerceDbContext _context;

        public CustomerRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetById(Guid id) => await _context.Customers.FindAsync(id);
    }
}

using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> GetById(Guid id);
        public Task<IEnumerable<Product>> GetAll();
        public Task Update(Product product);
    }
}

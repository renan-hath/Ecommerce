using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.Interfaces
{
    public interface IProductService
    {
        public Task Add(Product product);
        public Task<Product> GetById(Guid id);
        public Task<IEnumerable<Product>> GetAll();
        public Task Update(Product product);
        public Task Delete(Guid id);
    }
}

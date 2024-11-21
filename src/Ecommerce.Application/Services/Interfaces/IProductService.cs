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
        public Task<Product> GetProductById(Guid id);
        public Task<IEnumerable<Product>> GetProductsByIds(IEnumerable<Guid> ids);
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task UpdateProduct(Product product);
    }
}

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
        Product GetById(Guid id);
        IEnumerable<Product> GetAll();
        void Update(Product product);
    }
}

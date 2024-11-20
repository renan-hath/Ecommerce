using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _context;

        public ProductRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetById(Guid id) => await _context.Products.FindAsync(id);

        public async Task<IEnumerable<Product>> GetAll() => await _context.Products.ToListAsync();

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}

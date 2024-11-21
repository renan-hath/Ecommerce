using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _context;

        public ProductRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetById(Guid id) => await _context.Products.FindAsync(id);

        public async Task<IEnumerable<Product>> GetByIds(IEnumerable<Guid> ids)
        {
            return await _context.Products
                                 .Where(p => ids.Contains(p.Id))
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAll() => await _context.Products.ToListAsync();

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var product = await GetById(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}

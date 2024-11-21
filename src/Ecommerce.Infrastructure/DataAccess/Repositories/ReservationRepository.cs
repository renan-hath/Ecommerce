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
    public class ReservationRepository : IReservationRepository
    {
        private readonly EcommerceDbContext _context;

        public ReservationRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task Add(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetByCustomerId(Guid customerId)
        {
            return await _context.Reservations
                .Where(r => r.CustomerId == customerId)
                .ToListAsync();
        }
    }
}

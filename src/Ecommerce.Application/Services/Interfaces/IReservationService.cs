using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.Interfaces
{
    public interface IReservationService
    {
        public Task<Reservation> CreateReservation(Guid productId, Guid customerId);
        public Task<IEnumerable<Reservation>> GetReservationsByCustomer(Guid customerId);
        public Task<IEnumerable<Product>> GetProductsReservedByCustomer(Guid customerId);
    }
}

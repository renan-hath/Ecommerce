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
        public Task<Reservation> Add(Guid productId, Guid customerId);
        public Task<Reservation> GetById(Guid id);
        public Task<IEnumerable<Reservation>> GetAllByCustomerId(Guid customerId);
        public Task<IEnumerable<Reservation>> GetAll();
        public Task Update(Reservation reservation);
        public Task Delete(Guid id);
    }
}

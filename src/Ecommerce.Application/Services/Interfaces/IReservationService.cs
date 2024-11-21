using Ecommerce.Application.DataTransferObjects;
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
        public Task<Reservation> Add(Guid id, ReservationDto reservationDto);
        public Task<Reservation> GetById(Guid id);
        public Task<IEnumerable<Reservation>> GetAllByCustomerId(Guid customerId);
        public Task<IEnumerable<Product>> GetAllProductsReservedByCustomerId(Guid customerId);
        public Task<IEnumerable<Reservation>> GetAll();
        public Task<Reservation> Update(Reservation reservation);
        public Task Delete(Guid id);
        public void SetToExpire(Guid id);
        public Task Expire(Guid id);
    }
}

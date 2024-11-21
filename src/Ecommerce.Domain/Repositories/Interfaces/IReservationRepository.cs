using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        public Task Add(Reservation reservation);
        public Task<IEnumerable<Reservation>> GetByCustomerId(Guid customerId);
    }
}

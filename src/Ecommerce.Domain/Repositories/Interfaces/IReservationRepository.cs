using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        public Task Add(Reservation reservation);
        public Task<Reservation> GetById(Guid id);
        public Task<IEnumerable<Reservation>> GetByCustomerId(Guid customerId);
        public Task<IEnumerable<Reservation>> GetAll();
        public Task Update(Reservation reservation);
        public Task Delete(Guid id);
    }
}

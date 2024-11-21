using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool IsActive { get; set; }

        public Reservation(Guid productId, Guid customerId)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            CustomerId = customerId;
            ReservationDate = DateTime.UtcNow;
            IsActive = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Reservation> Reservations { get; set; } = new();

        public Customer(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Reservations = new();
        }
    }
}

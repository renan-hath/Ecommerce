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

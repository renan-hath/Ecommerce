namespace Ecommerce.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public Product(string name, string status)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = status;
        }
    }
}

namespace Ecommerce.API.Requests
{
    public class RequestCreateReservation
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}

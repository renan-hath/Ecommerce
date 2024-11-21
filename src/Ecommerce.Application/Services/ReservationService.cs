using Ecommerce.Application.DataTransferObjects;
using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories.Interfaces;

namespace Ecommerce.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IJobScheduler _jobScheduler;
        private const string _productStatusAvailable = "disponível";
        private const string _productStatusUnavailable = "indisponível";
        private const string _productStatusReserved = "reservado";
        private const int _reservationExpirationDays = 3;

        public ReservationService(IReservationRepository reservationRepository, ICustomerService customerService, IProductService productService, IJobScheduler jobScheduler)
        {
            _reservationRepository = reservationRepository;
            _customerService = customerService;
            _productService = productService;
            _jobScheduler = jobScheduler;
        }

        public async Task<Reservation> Add(Guid id, ReservationDto reservationDto)
        {
            var product = await _productService.GetById(id);

            if (product == null || product.Status.Equals(_productStatusReserved) || product.Status.Equals(_productStatusUnavailable))
            {
                throw new InvalidOperationException("The product is invalid or currently unavailable.");
            }

            var customer = await _customerService.GetById(reservationDto.CustomerId);

            if (customer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            var reservation = new Reservation(product.Id, customer.Id);

            var productDto = new ProductDto
            {
                Name = product.Name,
                Status = _productStatusReserved
            };

            await _productService.Update(product.Id, productDto);
            await _reservationRepository.Add(reservation);
            SetToExpire(reservation.Id);

            return reservation;
        }

        public async Task<Reservation> GetById(Guid id)
        {
            var reservation = await _reservationRepository.GetById(id);

            if (reservation == null) { throw new KeyNotFoundException("Reservation not found."); }

            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetAllByCustomerId(Guid customerId)
        {
            var customer = await _customerService.GetById(customerId);

            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }

            return await _reservationRepository.GetByCustomerId(customerId);
        }

        public async Task<IEnumerable<Product>> GetAllProductsReservedByCustomerId(Guid customerId)
        {
            var reservations = await GetAllByCustomerId(customerId);

            if (reservations == null || !reservations.Any())
            {
                throw new KeyNotFoundException("No reservations found for the given customer.");
            }

            var productIds = reservations.Select(r => r.ProductId).Distinct();

            var products = await _productService.GetByIds(productIds);

            return products;
        }

        public async Task<IEnumerable<Reservation>> GetAll() => await _reservationRepository.GetAll();

        public async Task<Reservation> Update(Reservation reservation)
        {
            await _reservationRepository.Update(reservation);

            return reservation;
        }

        public async Task Delete(Guid id)
        {
            await _reservationRepository.Delete(id);
        }

        public void SetToExpire(Guid id)
        {
            _jobScheduler.Schedule<ReservationService>(
                service => service.Expire(id),
                TimeSpan.FromDays(_reservationExpirationDays)
            );
        }
        public async Task Expire(Guid id)
        {
            var reservation = await GetById(id);
            if (reservation == null || !reservation.IsActive) { return; }
            reservation.IsActive = false;

            var product = await _productService.GetById(reservation.ProductId);
            if (product == null) { return; }
            var productDto = new ProductDto
            {
                Name = product.Name,
                Status = _productStatusAvailable
            };

            await _productService.Update(product.Id, productDto);
            await Update(reservation);
        }
    }
}

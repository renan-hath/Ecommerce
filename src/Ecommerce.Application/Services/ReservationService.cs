using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private const string _productStatusAvailable = "disponível";
        private const string _productStatusUnavailable = "indisponível";
        private const string _productStatusReserved = "reservado";

        public ReservationService(IReservationRepository reservationRepository, ICustomerService customerService, IProductService productService)
        {
            _reservationRepository = reservationRepository;
            _customerService = customerService;
            _productService = productService;
        }

        public async Task<Reservation> Add(Guid productId, Guid customerId)
        {
            var product = await _productService.GetById(productId);

            if (product == null || product.Status.Equals(_productStatusAvailable) || product.Status.Equals(_productStatusUnavailable))
            {
                throw new InvalidOperationException("The product is invalid or currently unavailable.");
            }

            var customer = await _customerService.GetById(customerId);

            if (customer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            var reservation = new Reservation(product.Id, customer.Id);

            product.Status = _productStatusReserved;
            await _productService.Update(product);
            await _reservationRepository.Add(reservation);

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

        public async Task<IEnumerable<Reservation>> GetAll() => await _reservationRepository.GetAll();

        public async Task Update(Reservation reservation)
        {
            await _reservationRepository.Update(reservation);
        }

        public async Task Delete(Guid id)
        {
            await _reservationRepository.Delete(id);
        }
    }
}

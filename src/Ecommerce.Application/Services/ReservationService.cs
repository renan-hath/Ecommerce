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

        public ReservationService(IReservationRepository reservationRepository, ICustomerService customerService, IProductService productService)
        {
            _reservationRepository = reservationRepository;
            _customerService = customerService;
            _productService = productService;
        }

        public async Task<Reservation> CreateReservation(Guid productId, Guid customerId)
        {
            var product = await _productService.GetProductById(productId);

            if (product == null || product.Equals("reservado") || product.Equals("indisponível"))
            {
                throw new InvalidOperationException("The product is invalid or currently unavailable.");
            }

            var customer = await _customerService.GetById(customerId);

            if (customer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            var reservation = new Reservation(product.Id, customer.Id);

            product.Status = "reservado";
            await _productService.UpdateProduct(product);
            await _reservationRepository.Add(reservation);

            return reservation;
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByCustomer(Guid customerId)
        {
            var customer = await _customerService.GetById(customerId);

            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }

            return await _reservationRepository.GetByCustomerId(customerId);
        }

        public async Task<IEnumerable<Product>> GetProductsReservedByCustomer(Guid customerId)
        {
            var customer = await _customerService.GetById(customerId);

            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }

            var reservations = await GetReservationsByCustomer(customerId);

            var productsIds = reservations.Select(r => r.ProductId).Distinct();
            var products = await _productService.GetProductsByIds(productsIds);

            return products;
        }
    }
}

using Ecommerce.API.Requests;
using Ecommerce.Application.Services;
using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IReservationService _reservationService;

        public ReservationController(IProductService productService, IReservationService reservationService)
        {
            _productService = productService;
            _reservationService = reservationService;
        }

        [HttpPost("products/{id}/reserve")]
        public async Task<IActionResult> CreateReservation([FromBody] RequestCreateReservation request)
        {
            try
            {
                var reservation = await _reservationService.CreateReservation(request.ProductId, request.CustomerId);

                return Ok(reservation);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("customer/{id_customer}/reservations")]
        public async Task<IActionResult> GetProductsReservedByCustomer(Guid customerId)
        {
            try
            {
                var reservedProducts = await _reservationService.GetProductsReservedByCustomer(customerId);

                return Ok(reservedProducts);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();

            return Ok(products);
        }
    }
}
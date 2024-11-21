using Ecommerce.Application.Services;
using Ecommerce.Application.Services.Interfaces;
using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IReservationService _reservationService;

        public CustomerController(ICustomerService customerService, IReservationService reservationService)
        {
            _customerService = customerService;
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            await _customerService.Add(customer);
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAll();
            return Ok(customers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] Customer updatedCustomer)
        {
            updatedCustomer.Id = id;
            await _customerService.Update(updatedCustomer);
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerService.Delete(id);
            return NoContent();
        }

        [HttpGet("{id_customer}/reservations")]
        public async Task<IActionResult> GetCustomerReservations(Guid customerId)
        {
            try
            {
                var reservedProducts = await _reservationService.GetAllByCustomerId(customerId);

                return Ok(reservedProducts);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

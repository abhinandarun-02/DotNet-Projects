using Customers.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customers.API.Models;

namespace Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetCustomers() 
        {
            var customers = _customerRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(Guid id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if(customer == null)
            {
                return NotFound($"Customer with id = {id} is not found");
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            var addedCustomer = _customerRepository.AddCustomer(customer);
            return Ok(addedCustomer);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer([FromRoute] Guid id, [FromBody] Customer customer)
        {
            var updatedCustomer = _customerRepository.UpdateCustomer(id, customer);

            if (updatedCustomer==null)
            {
                return NotFound($"Customer with id = {id} is not found");
            }
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer([FromRoute] Guid id)
        {
            var isDeleted = _customerRepository.DeleteCustomer(id);

            if (!isDeleted)
            {
                return NotFound($"Customer with id = {id} is not found");
            }
            return Ok("Customer deleted successfully");
        }
    }
}

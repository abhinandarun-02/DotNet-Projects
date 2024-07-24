using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIRST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public string GetCustomer()
        {
            return "Customer details";
        }

        [HttpGet("{id}")]
        public string GetCustomer(int id)
        {
            return "Customer details for id: " + id;
        }
    }
}

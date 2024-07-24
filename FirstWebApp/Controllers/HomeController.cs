using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Customer Profile Page";
            var customer = new Customer("Abhinand Arun", "abhinand@email.com", "9868968969");
            ViewData["Customer"] = customer;



            return View(customer);
        }
    }
}

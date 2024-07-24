using Microsoft.AspNetCore.Mvc;

namespace Smartphones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartphonesController : ControllerBase
    {
        ISmartphoneRepository _smartphoneRepository;
        public SmartphonesController(ISmartphoneRepository smartphoneRepository)
        {
            _smartphoneRepository = smartphoneRepository;
        }

        [HttpGet]
        public IActionResult GetSmartphones()
        {
            var smartphones = _smartphoneRepository.GetSmartphones();
            return Ok(smartphones);
        }

        [HttpGet("{id}")]
        public IActionResult GetSmartphone(int id)
        {
            var smartphone = _smartphoneRepository.GetSmartphone(id);
            return Ok(smartphone);
        }

        [HttpPost]
        public IActionResult AddSmartphone(Smartphone smartphone)
        {
            var result = _smartphoneRepository.AddSmartphone(smartphone);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateSmartphone(Smartphone smartphone)
        {
            var result = _smartphoneRepository.UpdateSmartphone(smartphone);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSmartphone(int id)
        {
            var result = _smartphoneRepository.DeleteSmartphone(id);
            return Ok(result);
        }

        [HttpGet("price_stats")]
        public IActionResult GetPriceStats()
        {
            var minPrice = _smartphoneRepository.GetMinPrice();
            var avgPrice = _smartphoneRepository.GetAvgPrice();
            return Ok(new { MinPrice = minPrice, AvgPrice = avgPrice });
        }

        [HttpGet("launch_date_and_price/{price}")]
        public IActionResult GetSmartphonesByLaunchDateAndPrice([FromRoute] double price)
        {
            var smartphones = _smartphoneRepository.GetSmartphonesByLaunchDateAndPrice(price);
            return Ok(smartphones);
        }
    }
}

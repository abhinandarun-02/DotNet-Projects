using Cars.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarRepository _carRepository;
        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _carRepository.GetCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var car = await _carRepository.GetCar(id);
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(Car car)
        {
            var result = await _carRepository.AddCar(car);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar([FromRoute] int id, Car car)
        {
            var result = await _carRepository.UpdateCar(id, car);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int id)
        {
            var result = await _carRepository.DeleteCar(id);
            return Ok(result);
        }
    }
}

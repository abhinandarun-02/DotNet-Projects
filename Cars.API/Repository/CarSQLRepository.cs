using Cars.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.API
{
    public class CarSQLRepository : ICarRepository
    {

        CarDbContext _dbContext;

        public CarSQLRepository(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddCar(Car car)
        {
            await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Car> DeleteCar(int id)
        {
            var car = await GetCar(id);
            if (car != null)
            {
                _dbContext.Cars.Remove(car);
                await _dbContext.SaveChangesAsync();
            }
            return car;
        }

        public async Task<Car> GetCar(int id)
        {
            var car = await _dbContext.Cars.FirstOrDefaultAsync(e => e.Id == id);
            return car;
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            var cars = await _dbContext.Cars.ToListAsync();
            return cars;
        }

        public async Task<bool> UpdateCar(int id, Car car)
        {
            var existingCar = await GetCar(id);
            if (existingCar != null)
            {
                existingCar.Name = car.Name;
                existingCar.Category = car.Category;
                existingCar.Price = car.Price;
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }
    }
}

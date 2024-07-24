
//using Cars.API.Models;

//namespace Cars.API;

//public class CarEFCoreInMemoryRepository : ICarRepository
//{
//    CarDbContext _dbContext;

//    public CarEFCoreInMemoryRepository(CarDbContext dbContext)
//    {
//        _dbContext = dbContext;
//        DbInitializer.SeedData(_dbContext);

//    }

//    public IEnumerable<Car> GetCars()
//    {
//        return _dbContext.Cars;
//    }

//    public Car GetCar(int id)
//    {
//        var car = _dbContext.Cars.FirstOrDefault(c => c.Id == id);
//        if (car == null)
//        {
//            return null;
//        }
//        return car;
//    }

//    public Car AddCar(Car car)
//    {
//        var addedCar = _dbContext.Cars.Add(car);
//        _dbContext.SaveChanges();
//        return addedCar.Entity;
//    }

//    public Car UpdateCar(Car car)
//    {
//        var existingCar = GetCar(car.Id);
//        if (existingCar != null)
//        {
//            existingCar.Name = car.Name;
//            existingCar.Category = car.Category;
//            existingCar.Price = car.Price;
//            _dbContext.SaveChanges();
//        }
//        return existingCar;

//    }

//    public Car DeleteCar(int id)
//    {
//        var existingCar = GetCar(id);
//        if (existingCar != null)
//        {
//            _dbContext.Cars.Remove(existingCar);
//            _dbContext.SaveChanges();
//        }
//        return existingCar;
//    }

//    public double GetMinPrice()
//    {
//        return _dbContext.Cars.Min(c => c.Price);
//    }

//    public double GetAvgPrice()
//    {
//        return _dbContext.Cars.Average(c => c.Price);
//    }

//    public IEnumerable<Car> GetCarsByLaunchDateAndPrice(double price)
//    {
//        return _dbContext.Cars.Where(c => c.LaunchDate > DateTime.Now && c.Price <= price);
//    }

//}

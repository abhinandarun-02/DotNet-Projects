using Cars.API.Models;

namespace Cars.API
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCars();
        Task<Car> GetCar(int id);
        Task<bool> AddCar(Car car);
        Task<bool> UpdateCar(int id, Car car);
        Task<Car> DeleteCar(int id);
    }
}

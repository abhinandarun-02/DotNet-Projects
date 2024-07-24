using Cars.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.API
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var carOne = new Car { Id = 1, Name = "BMW", Category = "SUV", Price = 3000 };
            var carTwo = new Car { Id = 2, Name = "Audi", Category = "Sedan", Price = 2000 };

            modelBuilder.Entity<Car>().HasData(carOne, carTwo);
        }

        public DbSet<Car> Cars { get; set; }
    }

}

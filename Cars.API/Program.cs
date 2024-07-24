using Microsoft.EntityFrameworkCore;

namespace Cars.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services.AddDbContext<CarDbContext>(options => options.UseInMemoryDatabase("CarDb"));
            //builder.Services.AddScoped<ICarRepository, CarEFCoreInMemoryRepository>();

            builder.Services.AddDbContext<CarDbContext>(
                options =>
                {
                    var connectionString = builder.Configuration.GetConnectionString("CarDBConnection");
                    options.UseSqlServer(connectionString);
                }
                );
            builder.Services.AddScoped<ICarRepository, CarSQLRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

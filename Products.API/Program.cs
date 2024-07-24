using Microsoft.EntityFrameworkCore;
using Products.API.Data;
using Products.API.Repository;

namespace Products.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IProductRepository, ProductEFCoreInMemoryRepository>();

            builder.Services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseInMemoryDatabase("ProductDb");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

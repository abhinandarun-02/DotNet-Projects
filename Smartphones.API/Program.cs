using Microsoft.EntityFrameworkCore;

namespace Smartphones.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<ISmartphoneRepository, SmartphoneEFCoreInMemoryRepository>();

            builder.Services.AddDbContext<SmartphoneDbContext>(options => { options.UseInMemoryDatabase("SmartphonesDB"); });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

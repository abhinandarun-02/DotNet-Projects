using EmployeeManagement.API.Data;
using EmployeeManagement.API.Repository;
using EmployeeManagement.API.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepsitory>();

            builder.Services.AddDbContext<EmployeeDbContext>(
                    options =>
                    {
                        var connectionString = builder.Configuration.GetConnectionString("EmployeeDbConnection");

                        options.UseSqlServer(connectionString);
                    });


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

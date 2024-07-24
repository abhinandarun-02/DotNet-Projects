using Products.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Products.API.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

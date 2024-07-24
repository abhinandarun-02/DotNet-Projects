using Microsoft.EntityFrameworkCore;

namespace Smartphones.API;

public class SmartphoneDbContext : DbContext
{
    public SmartphoneDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Smartphone> Smartphones { get; set; }
}

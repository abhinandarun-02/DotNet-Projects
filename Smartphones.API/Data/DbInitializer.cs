namespace Smartphones.API;

public static class DbInitializer
{
    public static void SeedData(SmartphoneDbContext context)
    {
        if (!context.Smartphones.Any())
        {
            context.Smartphones.AddRange(
                new Smartphone { Id = 1, Name = "Apple", Features = "None", Price = 999, LaunchDate = DateTime.Parse("2025-09-14") },
                new Smartphone { Id = 2, Name = "Samsung", Features = "None", Price = 899, LaunchDate = DateTime.Parse("2023-09-14") },
                new Smartphone { Id = 3, Name = "Google", Features = "None", Price = 699, LaunchDate = DateTime.Parse("2024-09-14") }
            );
            context.SaveChanges();
        }
    }
}
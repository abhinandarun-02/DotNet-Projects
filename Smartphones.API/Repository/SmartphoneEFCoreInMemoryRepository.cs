
namespace Smartphones.API;

public class SmartphoneEFCoreInMemoryRepository : ISmartphoneRepository
{
    SmartphoneDbContext _dbContext;

    public SmartphoneEFCoreInMemoryRepository(SmartphoneDbContext dbContext)
    {
        _dbContext = dbContext;
        DbInitializer.SeedData(_dbContext);

    }

    public IEnumerable<Smartphone> GetSmartphones()
    {
        return _dbContext.Smartphones;
    }

    public Smartphone GetSmartphone(int id)
    {
        var smartphone = _dbContext.Smartphones.FirstOrDefault(c => c.Id == id);
        if (smartphone == null)
        {
            return null;
        }
        return smartphone;
    }

    public Smartphone AddSmartphone(Smartphone smartphone)
    {
        var addedSmartphone = _dbContext.Smartphones.Add(smartphone);
        _dbContext.SaveChanges();
        return addedSmartphone.Entity;
    }

    public Smartphone UpdateSmartphone(Smartphone smartphone)
    {
        var existingSmartphone = GetSmartphone(smartphone.Id);
        if (existingSmartphone != null)
        {
            existingSmartphone.Name = smartphone.Name;
            existingSmartphone.Features = smartphone.Features;
            existingSmartphone.LaunchDate = smartphone.LaunchDate;
            existingSmartphone.Price = smartphone.Price;
            _dbContext.SaveChanges();
        }
        return existingSmartphone;

    }

    public Smartphone DeleteSmartphone(int id)
    {
        var existingSmartphone = GetSmartphone(id);
        if (existingSmartphone != null)
        {
            _dbContext.Smartphones.Remove(existingSmartphone);
            _dbContext.SaveChanges();
        }
        return existingSmartphone;
    }

    public double GetMinPrice()
    {
        return _dbContext.Smartphones.Min(c => c.Price);
    }

    public double GetAvgPrice()
    {
        return _dbContext.Smartphones.Average(c => c.Price);
    }

    public IEnumerable<Smartphone> GetSmartphonesByLaunchDateAndPrice(double price)
    {
        return _dbContext.Smartphones.Where(c => c.LaunchDate > DateTime.Now && c.Price <= price);
    }

}

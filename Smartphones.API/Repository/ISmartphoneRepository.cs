namespace Smartphones.API;

public interface ISmartphoneRepository
{
    // CRUD methods
    public IEnumerable<Smartphone> GetSmartphones();
    public Smartphone GetSmartphone(int id);
    public Smartphone AddSmartphone(Smartphone smartphone);
    public Smartphone UpdateSmartphone(Smartphone smartphone);
    public Smartphone DeleteSmartphone(int id);

    // 4. Create a new API end point which returns the minimum & average price of phone as response
    public double GetMinPrice();
    public double GetAvgPrice();

    // 5. Create a new API endpoint which returns all phones, where the launch date is greater than current date and price is less than or equal to the price passed as an input.
    public IEnumerable<Smartphone> GetSmartphonesByLaunchDateAndPrice(double price);

}

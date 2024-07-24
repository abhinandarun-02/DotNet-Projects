namespace FirstWebApp.Models
{
    public class Customer
    {
        public string Name;
        public string Email;
        public string Phone;

        public Customer(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}

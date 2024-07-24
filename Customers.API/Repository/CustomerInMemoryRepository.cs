using Customers.API.Models;

namespace Customers.API.Repository
{
    public class CustomerInMemoryRepository : ICustomerRepository
    {
        private List<Customer> _customerList = new List<Customer>();

        public CustomerInMemoryRepository()
        {
            _customerList.Add(new Customer { Name = "Nikhil", Email = "Nikhil@test.com" });
            _customerList.Add(new Customer { Name = "Uday", Email = "Uday@test.com" });
            _customerList.Add(new Customer { Name = "Ullas", Email = "Ullas@test.com" });
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerList;
        }

        public Customer GetCustomerById(Guid id)
        {
            var customer = _customerList.FirstOrDefault(c => c.Id == id);
            return customer;
        }

        public Customer AddCustomer(Customer customer)
        {
            _customerList.Add(customer);
            return customer;
        }

        public Customer UpdateCustomer(Guid id, Customer customer)
        {
            var existingCustomer = _customerList.FirstOrDefault(c => c.Id == id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
            }
            return existingCustomer;
        }

        public bool DeleteCustomer(Guid id)
        {
            var existingCustomer = _customerList.FirstOrDefault(c => c.Id == id);

            if (existingCustomer != null)
            {
                _customerList.Remove(existingCustomer);
                return true;
            }
            return false;
        }
    }
}

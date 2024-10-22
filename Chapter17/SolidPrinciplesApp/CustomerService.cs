namespace SolidPrinciplesApp
{
    // Dependency Inversion Principle
    // aims to reduce dependencies among high-level and low-level modules by introducing an abstraction layer
    // Note: these would probably be broken out into separate files in a real-world app
    public interface ICustomerRepository
    {
        void Add(Customer customer);
    }

    public class CustomerRepository : ICustomerRepository
    {
        public void Add(Customer customer)
        {
            WriteLine("Customer has been added");
        }
    }

    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void RegisterCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime DateCreated { get; set; }
    }
}

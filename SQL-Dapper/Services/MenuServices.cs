using SQL_Dapper.Models;

namespace SQL_Dapper.Services
{
    public class MenuServices(CustomerServices customerServices)
    {
        private readonly CustomerServices _customerServices = customerServices;

        public void CreateNewCustomerMenu()
        {
               Console.Clear();
            Console.WriteLine("Create new customer");
            Console.WriteLine("-------------------");
            Console.WriteLine("First name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Last name:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Email:");
            var email = Console.ReadLine();
            Console.WriteLine("Phone:");
            var phone = Console.ReadLine();
            Console.WriteLine("Street name:");
            var streetName = Console.ReadLine();
            Console.WriteLine("Postal code:");
            var postalCode = Console.ReadLine();
            Console.WriteLine("City:");
            var city = Console.ReadLine();

            var form = new CustomerRegistationForm
            {
                FirstName = firstName!,
                LastName = lastName!,
                Email = email!,
                Phone = phone,
                StreetName = streetName!,
                PostalCode = postalCode!,
                City = city!
            };

            var result = _customerServices.CreateCustomer(form);

            if (result)
            {
                Console.WriteLine("Customer was created");
            }
            else
            {
                Console.WriteLine("Customer was not created");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

    }
}

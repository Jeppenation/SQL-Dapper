using SQL_Dapper.Models;
using SQL_Dapper.Models.Entities;
using SQL_Dapper.Repositories;

namespace SQL_Dapper.Services
{
    public class CustomerServices(CustomerRepository customerRepository, AddressRepository addressRepository)
    {
        private readonly CustomerRepository _customerRepository = customerRepository;
        private readonly AddressRepository _addressRepository = addressRepository!;


        public bool CreateCustomer(CustomerRegistationForm form)
        {


            
            var customerEntity = new CustomerEntity 
            { 
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                PhoneNumber = form.Phone,

                //We are using the Create method from the AddressRepository to create a new address and get the Id of the newly created address
                //We started with doing this by it self, but to add the addressId, we need to do it like this
                AdressId = addressRepository.Create(new AddressEntity
                {
                    StreetName = form.StreetName,
                    PostalCode = form.PostalCode,
                    City = form.City
                })
            };
        
            int result = _customerRepository.Create(customerEntity);

            //If the result is greater than 0, then the customer was created
            return result > 0;

            //In short, in this example we used two repositories to create a customer, we used the AddressRepository to create a new address and get the Id of the newly created address,
            //and then we used the CustomerRepository to create a new customer and set the AddressId to the Id of the newly created address
            
        }
    }
}

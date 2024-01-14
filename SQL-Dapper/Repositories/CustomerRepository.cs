using Dapper;
using Microsoft.Data.SqlClient;
using SQL_Dapper.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Dapper.Repositories
{
    public class CustomerRepository(string connectionString)
    {
        private readonly string _connectionString = connectionString;
        public int Create(CustomerEntity entity)
        {
            //We are using the using statement to make sure that the connection is closed after the query is executed
            using var conn = new SqlConnection(_connectionString);

            //Since we are using Dapper, we dont need to set the different variable names in the query, we can just use the entity object and Dapper will map the properties to the query
            var result = conn.ExecuteScalar<int>("INSERT INTO Customers OUTPUT inserted.Id VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @AdressId);", entity);


            //We are returning the Id of the newly created Customer
            return result;
        }

    }
}

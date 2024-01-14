using Dapper;
using Microsoft.Data.SqlClient;
using SQL_Dapper.Models.Entities;

namespace SQL_Dapper.Repositories
{
    public class AddressRepository(string connectionString)
    {
        //We are using the readonly keyword to make sure that the connection string is not changed after it has been set in the constructor
        private readonly string _connectionString = connectionString;

        public int Create(AddressEntity entity)
        {
            //We are using the using statement to make sure that the connection is closed after the query is executed
            using var conn = new SqlConnection(_connectionString);

            //Since we are using Dapper, we dont need to set the different variable names in the query, we can just use the entity object and Dapper will map the properties to the query
            var result = conn.ExecuteScalar<int>("IF NOT EXISTS (SELECT 1 FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode AND City = @City) INSERT INTO Addresses OUTPUT inserted.Id VALUES (@StreetName, @PostalCode, @City) ELSE SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode AND City = @City;", entity);


            //We are returning the Id of the newly created address
            return result;
        }
    }
}

namespace SQL_Dapper.Models.Entities
{
    public class CustomerEntity
    {
        //same as in DB
        public int id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public int AdressId { get; set; }
    }
}

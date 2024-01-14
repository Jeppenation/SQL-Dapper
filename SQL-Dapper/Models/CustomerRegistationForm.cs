namespace SQL_Dapper.Models
{
    public class CustomerRegistationForm
    {
        //What the user will fill in, since the user will not fill in the id, we don't need it here
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}

namespace SQL_Dapper.Models.Entities
{
    public class AddressEntity
    {
        //same as in DB
        public int Id { get; set; }
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;


    }
}

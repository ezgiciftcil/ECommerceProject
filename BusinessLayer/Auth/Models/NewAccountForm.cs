namespace BusinessLayer.Auth.Models
{
    public class NewAccountForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public bool IsAddressWanted { get; set; }
        public string Country { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public string AddressDesc { get; set; }
    }
}

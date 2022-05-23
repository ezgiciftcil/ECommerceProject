namespace EntityLayer
{
    public class Address:IEntity
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Street { get; set; }
        public string AddressDescription { get; set; }
        public int PostCode { get; set; }
    }
}

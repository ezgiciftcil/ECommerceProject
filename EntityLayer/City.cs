using System.Collections.Generic;

namespace EntityLayer
{
    public class City : IEntity
    {
        public City()
        {
            Addresses = new List<Address>();
            OrderAddresses = new List<OrderAddress>();
        }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<Address> Addresses { get; set; }
        public List<OrderAddress> OrderAddresses { get; set; }
    }
}

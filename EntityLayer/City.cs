using System.Collections.Generic;

namespace EntityLayer
{
    public class City:IEntity
    {
        public City()
        {
           Addresses = new List<Address>();
        }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<Address> Addresses { get; set; }
    }
}

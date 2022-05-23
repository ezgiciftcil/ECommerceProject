using System.Collections.Generic;

namespace EntityLayer
{
    public class City:IEntity
    {
        public City()
        {
                if (Addresses == null)
                    Addresses = new List<Address>();
        }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<Address> Addresses { get; set; }
    }
}

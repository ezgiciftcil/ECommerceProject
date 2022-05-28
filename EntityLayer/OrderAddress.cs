using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class OrderAddress:IEntity
    {
        public OrderAddress()
        {
            if (Orders == null)
                Orders = new List<Order>();
        }
        public int AddressId { get; set; }
        public string Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Street { get; set; }
        public string AddressDescription { get; set; }
        public int PostCode { get; set; }
        public string OrderGuid { get; set; }
        public List<Order> Orders { get; set; }
    }
}

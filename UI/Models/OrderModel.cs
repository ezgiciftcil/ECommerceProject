using EntityLayer;

namespace UI.Models
{
    public class OrderModel
    {
        public CartModel Cart { get; set; }
        public Address Address { get; set; }
        public bool IsDefaultAddressExists { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Discount:IEntity
    {
        public int DiscountId { get; set; }
        public string DiscountDescription { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

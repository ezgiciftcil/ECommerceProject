using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class HomePageModel
    {
        public List<Category> Categories { get; set; }
        public IDictionary<int,int> CategoryTotalProduct { get; set; }
       
    }
}

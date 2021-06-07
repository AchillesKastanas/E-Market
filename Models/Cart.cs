using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emarket.Models
{
    public class Cart
    {
        public string CartID { get; set; }
        public string UserID { get; set; }
        public List<Product> ProductsList { get; set; } // contains all the users products ?
    }
}
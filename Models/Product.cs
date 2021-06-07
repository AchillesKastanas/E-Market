using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emarket.Models
{
    public class Product
    {
        public string productID { get; set; }
        public string Info { get; set; }
        public string Price { get; set; }
        public string AvailableQuantity { get; set; }
        public string sourceOfImage { get; set; }
        public string categoryName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emarket.Models
{
    public class Payment
    {
        public string Address { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string cartCode { get; set; }
        public string CVV { get; set; }
        public double CartPrice { get; set; }
        public double TotalPrice { get; set; }
        public double Shipping = 5;
    }
}
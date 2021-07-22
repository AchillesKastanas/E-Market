using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emarket.Models
{
    public class Cart
    {
        public void AddToCart(Product product)
        {
            products.Add(product);
        }
        public string CartID { get; set; }
        public List<Product> products = new List<Product>();
    }
}
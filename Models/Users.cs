using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_market.Models
{
    public class Users
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsVendor { get; set; }
        public string LastLogin { get; set; }
    }
}
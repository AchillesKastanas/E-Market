using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emarket.Models
{
    public class Payment
    {
        public string Address { get; set; }

        //Phone Validation
        [Required(ErrorMessage = "Please Enter Phone Number")]
        [Display(Name = "Number")]
        [StringLength(10, ErrorMessage = "The Phone number must contains 10 characters", MinimumLength = 10)]
        public string Number { get; set; }
        public string City { get; set; }

        //Zip Code Validation
        [Required(ErrorMessage = "Zip is Required")]
        [Display(Name = "ZipCode")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string ZipCode { get; set; }

        //Card Number Validation
        [Required(ErrorMessage = "Please Enter Card Number")]
        [Display(Name = "cardCode")]
        [StringLength(16, ErrorMessage = "The card number must contains 16 characters", MinimumLength = 16)]
        public string cardCode { get; set; }

        //CVV Validation
        [Required(ErrorMessage = "Please Enter CVV Number")]
        [Display(Name = "CVV")]
        [StringLength(3, ErrorMessage = "The CVV must contains 10 characters", MinimumLength = 3)]
        public string CVV { get; set; }
        public double CartPrice { get; set; }
        public double TotalPrice { get; set; }
        public double Shipping = 5;
    }
}
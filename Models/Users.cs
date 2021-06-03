using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace emarket.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        //Validation for first name
        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "firstname")]
        public string FirstName { get; set; }

        //Validation for last name
        [Required(ErrorMessage = "Please Enter Last Name")]
        [Display(Name = "lastname")]
        public string LastName { get; set; }

        //Validation for Phone number
        [Required(ErrorMessage = "Please Enter Phone Number")]
        [Display(Name = "Phone")]
        [StringLength(10, ErrorMessage = "The Phone number must contains 10 characters", MinimumLength = 10)]
        public int Phone { get; set; }

        //Validation for Email
        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsVendor { get; set; }
        //public string LastLogin { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC.Models
{
    public class LoginModels
    {
        [Required(ErrorMessage = "Please Enter Email")]
        [Display(Name = "Enter Email")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Email must be between 10 and 50 characters!")]
        [MaxLength(100, ErrorMessage = "Exceeding Limit")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Enter Password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 50 characters!")]
        public string password { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC.Models
{
    public class DataModels
    {
        public int userid { get; set; }

        [Required(ErrorMessage = "Please Enter User Name")]
        [Display(Name = "Enter User Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "User Name must be between 3 and 50 characters!")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [Display(Name = "Enter Email")]
        [MaxLength(100, ErrorMessage = "Exceeding Limit")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [Display(Name = "Enter Mobile Number")]
        [DataType(DataType.Currency)]
        public string mobile { get; set; }

        //[Required(ErrorMessage = "Please Enter User Gender")]
        [Display(Name = "Enter User Gender")]
        [DataType(DataType.Text)]
        public string gender { get; set; }

    }
}
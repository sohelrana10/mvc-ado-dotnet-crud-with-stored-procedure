using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CRUD_ADO_DOT_NET_STORPROCEDURE.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Employee Name is Required")]
        [Display(Name ="Employee Name")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Email Address is Required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email is not correct formate")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

    }
}
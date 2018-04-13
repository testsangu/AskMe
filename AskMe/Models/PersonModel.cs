using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AskMe.Models
{
    public class PersonModel
    {
        public int PersonId { get; set; }

        [Required(ErrorMessage="Please enter the First Name")]
        [Display(Name="First Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "alphanumeric is not allowed. Please enter the valid name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Please enter the Last Name")]
        [Display(Name="Last name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "alphanumeric is not allowed. Please enter the valid name")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Please Enter your Mobile no.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Mobile No.")]
        [StringLength(10)]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage="Please Enter the Email Id")]
        [Display(Name="Email Id")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Required(ErrorMessage="Please Enter the Gender")]
        public string Gender { get; set; } 
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        
    }
}
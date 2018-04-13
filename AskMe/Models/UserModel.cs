using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AskMe.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Roles = new List<SelectListItem>();
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Please Enter the User Name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; } 
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 5)]
        public string Password { get; set; } 
        public int? RoleId { get; set; }

        public IList<SelectListItem> Roles { get; set; }
        public long? LawFirmId { get; set; } 
        public bool? IsActive { get; set; } 
        public bool? IsDeleted { get; set; } 
        public System.DateTime? CreatedDate { get; set; } 
        public System.DateTime? UpdatedDate { get; set; } 
        public int? RewardPoints { get; set; } 
        public int? PersonId { get; set; } 







    }
}
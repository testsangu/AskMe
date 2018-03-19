using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AskMe.Models
{
    public class QCategoryViewModel
    {
        [Required]
        [Display(Name = "CategoryName")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "IsActive")]
        public string IsActive { get; set; }

        
        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }
    }
}
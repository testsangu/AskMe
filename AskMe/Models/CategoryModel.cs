using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AskMe.Models
{
    public class CategoryModel
    {
        [Display(Name = "Category Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter the Category Name")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AskMe.Models
{
    public class QuestionViewModel
    {
        public QuestionViewModel()
        {
            Category = new List<SelectListItem>();
        }
        public long Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Question Detail")]
        public string QuestionDetail { get; set; }
        [Required]
        [Display(Name = "Attachment")]
        public string FilePath { get; set; }
        [Required]
        [Display(Name = "I am interested to get call/message from Lawyer.")]
        public bool GetCall { get; set; }
        [Display(Name = "Notified by e-mail at incoming answers.")]
        public bool Notification { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public IList<SelectListItem> Category { get; set; }
        [Required(ErrorMessage = "Select item from the dropdown")]
        public Nullable<int> QuestionsCategoryId { get; set; }
        public Nullable<long> UserId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> ServiceLocationId { get; set; }
        [Display(Name = "Active this question as a private question.")]
        public bool Published { get; set; }
        public string IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
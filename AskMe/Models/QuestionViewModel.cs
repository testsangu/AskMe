using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AskMe.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
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
        public string GetCall { get; set; }
        [Display(Name = "Notified by e-mail at incoming answers.")]
        public bool Notification { get; set; }
        public int QuestionsCategoryId { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public int ServiceLocationId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
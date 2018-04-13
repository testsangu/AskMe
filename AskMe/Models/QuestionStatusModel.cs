using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskMe.Models
{
    public class QuestionStatusModel
    {
        public int Id { get; set; } 
        public string Status { get; set; } 
        public bool IsActive { get; set; } 
        public string CreatedBy { get; set; } 
        public System.DateTime CreatedDate { get; set; } 
    }
}
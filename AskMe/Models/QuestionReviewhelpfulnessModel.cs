using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskMe.Models
{
    public class QuestionReviewhelpfulnessModel
    {
        public int Id { get; set; } 
        public int QuestionReviewId { get; set; } 
        public bool WasHelpful { get; set; } 
        public int UserId { get; set; } 
    }
}
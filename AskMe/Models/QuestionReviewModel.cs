using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskMe.Models
{
    public class QuestionReviewModel
    {
            public int Id { get; set; } 
            public int UserId { get; set; } 
            public int QuestionId { get; set; } 
            public bool IsApproved { get; set; } 
            public string Title { get; set; } 
            public string ReviewText { get; set; } 
            public string ReplyText { get; set; } 
            public int Rating { get; set; } 
            public int HelpfulYesTotal { get; set; } 
            public int HelpfulNoTotal { get; set; }
            public System.DateTime CreatedOnUtc { get; set; } 
        
    }
}
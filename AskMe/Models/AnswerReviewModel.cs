using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskMe.Models
{
    public class AnswerReviewModel
    {
            public int Id { get; set; }
            public int UserId { get; set; } 
            public int QuestionAnswerId { get; set; } 
            public bool IsApproved { get; set; } 
            public bool IsReviewed { get; set; } 
            public string Title { get; set; } 
            public string ReviewText { get; set; } 
            public string ReplyText { get; set; } 
            public int? Rating { get; set; } 
            public System.DateTime CreatedOnUtc { get; set; } 
        
    }
}
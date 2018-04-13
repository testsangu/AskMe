using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskMe.Models
{
    public class QuestionAnswerModel
    {
        public long Id { get; set; } 
        public string AnswerTitle { get; set; } 
        public string AnswerDescription { get; set; } 
        public int AnswerStatusId { get; set; } 
        public int? AnswerCommentId { get; set; } 
        public int ParentAnswerId { get; set; } 
        public long FromUserId { get; set; } 
        public long ToUserId { get; set; } 
        public long QuestionId { get; set; } 
        public bool Published { get; set; } 
        public bool IsActive { get; set; } 
        public string CreatedBy { get; set; } 
        public System.DateTime CreatedDate { get; set; } 
        public string UpdatedBy { get; set; } 
        public System.DateTime? UpdatedDate { get; set; } 
    }
}
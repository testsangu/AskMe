using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.AskUs;

namespace Business.Interfaces
{
    interface IAnswerReviewBAL
    {
        List<AnswerReview> GetAllAnswerReview();
        AnswerReview GetAnswerReviewById(int id);
        void AddAnswerReview(AnswerReview answerReview);
        
    }
}

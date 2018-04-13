using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.AskUs;

namespace Business.Interfaces
{
    interface IQuestionAnswerBAL
    {
        List<QuestionAnswer> GetAllQuestionAnswer();
        void AddQuestionAnswer(QuestionAnswer questoinAnswer);
        QuestionAnswer GetQuestionAnswerById(int id);
        void UpdateQuestionAnswer(QuestionAnswer questionAnswer);
    }
}

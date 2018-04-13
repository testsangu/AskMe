using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.AskUs;

namespace Business.Repository
{
    public class QuestionAnswerBAL : IQuestionAnswerBAL
    {
        public List<QuestionAnswer> GetAllQuestionAnswer()
        {
            using(var _context= new AskUsDbContext())
            {
                List<QuestionAnswer> QList = _context.QuestionAnswers.ToList();
                return QList;
            }
        }

        public void AddQuestionAnswer(QuestionAnswer questoinAnswer)
        {
           using(var _context= new AskUsDbContext())
           {
               _context.QuestionAnswers.Add(questoinAnswer);
               _context.SaveChanges();
           }
        }

        public QuestionAnswer GetQuestionAnswerById(int id)
        {
            using(var _context= new AskUsDbContext())
            {
                QuestionAnswer questionAnswer = _context.QuestionAnswers.Where(x => x.Id == id).FirstOrDefault();
                return questionAnswer;
            }
        }

        public void UpdateQuestionAnswer(QuestionAnswer questionAnswer)
        {
            using(var _context= new AskUsDbContext())
            {
                _context.Entry(questionAnswer).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}

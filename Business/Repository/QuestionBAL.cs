using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Data;
using System.Data.Entity;
using Data.AskUs;

namespace Business.Repository
{
    public class QuestionBAL : IQuestionBAL
    {
        public List<Question> GetAllQuestion()
        {
            using(var _context= new AskUsDbContext())
            {
               List<Question> qlist = _context.Questions.ToList();

                return qlist;
            }
        }

        public void AddQuestion(Question question)
        {
            using(var _context= new AskUsDbContext())
            {
                _context.Questions.Add(question);
                _context.SaveChanges();
            }
        }
        public void UpdateQuestion(Question question)
        {
            using(var _context= new AskUsDbContext())
            {
                _context.Entry(question).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public Question GetQuestionById(long id)
        {
            using(var _context= new AskUsDbContext())
            {
                Question q = _context.Questions.Where(x => x.Id == id).FirstOrDefault();
                return q;
            }

        }
    }
}

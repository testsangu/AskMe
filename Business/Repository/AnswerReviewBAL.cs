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
    public class AnswerReviewBAL : IAnswerReviewBAL
    {

        public List<AnswerReview> GetAllAnswerReview()
        {
            using(var _context= new AskUsDbContext())
            {
                List<AnswerReview> Alist = _context.AnswerReviews.ToList();
                return Alist;
            }
        }

        public AnswerReview GetAnswerReviewById(int id)
        {
            using(var _context = new AskUsDbContext())
            {
                AnswerReview answerReview = _context.AnswerReviews.Where(x => x.Id == id).FirstOrDefault();
                return answerReview;
            }
        }

        public void AddAnswerReview(AnswerReview answerReview)
        {
            using(var _context= new AskUsDbContext())
            {
                _context.AnswerReviews.Add(answerReview);               
                _context.SaveChanges();                
            }
        }
        public void UpdateAnswerReview(AnswerReview answerReview)
        {
            using(var _context= new AskUsDbContext())
            {
                _context.Entry(answerReview).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

    }
}

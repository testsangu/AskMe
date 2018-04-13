using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Data;
using Data.AskUs;

namespace Business.Repository
{
    public class CategoryBAL : ICategoryBAL
    {

        public List<QuestionsCategory> GetAllCategory()
        {
           using(var _context=new AskUsDbContext())
           {
               List<QuestionsCategory> list = _context.QuestionsCategories.ToList();
               return list;    
           }
                    
        }

        public void AddQuestionCategory(QuestionsCategory category)
        {
            using (var _context = new AskUsDbContext())
            {
                _context.QuestionsCategories.Add(category);
                _context.SaveChanges();
            }
        }

        public QuestionsCategory GetCategoryById(int id)
        {
            using(var _context= new AskUsDbContext())
            {
                QuestionsCategory Qcategory = _context.QuestionsCategories.Where(x => x.Id == id).FirstOrDefault();

                return Qcategory;
            }
        }
        public void UpdateQuestionsCategory(QuestionsCategory category)
        {
            using(var _context= new AskUsDbContext())
            {
                _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }
        public void DeleteQuestoinsCategory(QuestionsCategory category)
        {
            using(var _context= new AskUsDbContext())
            {
                _context.QuestionsCategories.Remove(category);
                _context.SaveChanges();
            }
        }
       
       
    }
}

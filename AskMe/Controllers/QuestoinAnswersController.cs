using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.AskUs;
using Business.Interfaces;
using Business.Repository;
using AskMe.Models;

namespace AskMe.Controllers
{
    public class QuestoinAnswersController : Controller
    {
        //
        // GET: /QuestoinAnswers/
        public ActionResult Index()
        {
            QuestionAnswerBAL _questionAnswerBAL = new QuestionAnswerBAL();
            List<QuestionAnswer> QAList = _questionAnswerBAL.GetAllQuestionAnswer();
            List<QuestionAnswerModel> _QAModel = new List<QuestionAnswerModel>();
            foreach(var q in QAList)
            {
                var model = new QuestionAnswerModel();
                model.Id = q.Id;
                model.AnswerTitle = q.AnswerTitle;
                model.AnswerDescription = q.AnswerDescription;
                model.AnswerCommentId = q.AnswerCommentId;
                model.AnswerStatusId = q.AnswerStatusId;
                model.CreatedBy = "Admin";
                model.FromUserId = 1;
                model.IsActive = q.IsActive;
                model.ParentAnswerId = 2;
                model.QuestionId = 1;
                model.ToUserId = 1;
                model.Published = true;
                model.CreatedDate = DateTime.Now.ToUniversalTime();
                model.UpdatedBy = q.UpdatedBy;
                model.UpdatedDate = q.UpdatedDate;

                _QAModel.Add(model);
            }
            return View(_QAModel);
        }

        //
        // GET: /QuestoinAnswers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /QuestoinAnswers/Create
        public ActionResult Create()
        {
           
            

            return View();
        }

        //
        // POST: /QuestoinAnswers/Create
        [HttpPost]
        public ActionResult Create(QuestionAnswerModel questionAnswer)
        {
            try
            {
                // TODO: Add insert logic here

                QuestionAnswer _questionAnswer = new QuestionAnswer();
                _questionAnswer.Id = questionAnswer.Id;
                _questionAnswer.AnswerTitle = questionAnswer.AnswerTitle;
                _questionAnswer.AnswerDescription = questionAnswer.AnswerDescription;
                _questionAnswer.AnswerCommentId = questionAnswer.AnswerCommentId;
                _questionAnswer.AnswerStatusId = questionAnswer.AnswerStatusId;
                _questionAnswer.CreatedBy = "Admin";
                _questionAnswer.FromUserId = 1;
                _questionAnswer.IsActive = true;
                _questionAnswer.ParentAnswerId = questionAnswer.ParentAnswerId;
                _questionAnswer.Published = true;
                _questionAnswer.CreatedDate = DateTime.Now.ToUniversalTime();
                _questionAnswer.ToUserId = 1;
                _questionAnswer.QuestionId = questionAnswer.QuestionId;
                QuestionAnswerBAL _questionAnswerBAL = new QuestionAnswerBAL();
                _questionAnswerBAL.AddQuestionAnswer(_questionAnswer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /QuestoinAnswers/Edit/5
        public ActionResult Edit(int id)
        {
            QuestionAnswerBAL _QuestionAnswerBAL = new QuestionAnswerBAL();
            QuestionAnswer _questionAnswer = _QuestionAnswerBAL.GetQuestionAnswerById(id);
            var model = new QuestionAnswerModel();
            model.Id = _questionAnswer.Id;
            model.AnswerTitle = _questionAnswer.AnswerTitle;
            model.AnswerDescription = _questionAnswer.AnswerDescription;
            model.AnswerCommentId = _questionAnswer.AnswerCommentId;
            model.AnswerStatusId = _questionAnswer.AnswerStatusId;
            model.FromUserId = _questionAnswer.FromUserId;
            model.IsActive = _questionAnswer.IsActive;
            model.QuestionId = _questionAnswer.QuestionId;
            model.ToUserId = _questionAnswer.ToUserId;
            model.UpdatedBy = "Admin";
            model.UpdatedDate = DateTime.Now.ToUniversalTime();
            model.Published = _questionAnswer.Published;
            model.ParentAnswerId = _questionAnswer.ParentAnswerId;
            _QuestionAnswerBAL.UpdateQuestionAnswer(_questionAnswer);

            return View(model);
        }

        //
        // POST: /QuestoinAnswers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, QuestionAnswerModel questionAnswer)
        {
            try
            {
                // TODO: Add update logic here
                QuestionAnswerBAL _QuestionAnswerBAL = new QuestionAnswerBAL();
                QuestionAnswer _questionAnswer = _QuestionAnswerBAL.GetQuestionAnswerById(id);
                _questionAnswer.Id = questionAnswer.Id;
                _questionAnswer.AnswerTitle = questionAnswer.AnswerTitle;
                _questionAnswer.AnswerDescription = questionAnswer.AnswerDescription;
                _questionAnswer.AnswerCommentId = questionAnswer.AnswerCommentId;
                _questionAnswer.AnswerStatusId = questionAnswer.AnswerStatusId;
                _questionAnswer.IsActive = questionAnswer.IsActive;
                _questionAnswer.ParentAnswerId = questionAnswer.ParentAnswerId;
                _questionAnswer.Published = questionAnswer.Published;
                _questionAnswer.QuestionId = questionAnswer.QuestionId;
                _questionAnswer.ToUserId = questionAnswer.ToUserId;
                _questionAnswer.UpdatedBy = "Admin";
                _questionAnswer.UpdatedDate = DateTime.Now.ToUniversalTime();
                _questionAnswer.FromUserId = questionAnswer.FromUserId;
                _QuestionAnswerBAL.UpdateQuestionAnswer(_questionAnswer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /QuestoinAnswers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /QuestoinAnswers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

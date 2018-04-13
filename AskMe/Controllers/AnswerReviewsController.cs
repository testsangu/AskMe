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
    public class AnswerReviewsController : Controller
    {
        //
        // GET: /AnswerReviews/
        public ActionResult Index()
        {
            AnswerReviewBAL _answerReviewBAL = new AnswerReviewBAL();
            List<AnswerReview> _AnswerRlist = _answerReviewBAL.GetAllAnswerReview();
            List<AnswerReviewModel> _AnswerRModel = new List<AnswerReviewModel>();

            foreach(var a in _AnswerRlist)
            {
                var model = new AnswerReviewModel();
                model.Id = a.Id;
                model.ReplyText = a.ReplyText;
                model.Title = a.Title;
                model.ReviewText = a.ReviewText;
                model.Rating = a.Rating;
                model.QuestionAnswerId = a.QuestionAnswerId;
                model.IsReviewed = a.IsReviewed;
                model.IsApproved = a.IsApproved;
                model.UserId = a.UserId;
                model.CreatedOnUtc = DateTime.Now.ToUniversalTime();
                _AnswerRModel.Add(model);
            }
            return View(_AnswerRModel);
        }

        //
        // GET: /AnswerReviews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AnswerReviews/Create
        public ActionResult Create()
        {           
            var Rmodel = new AnswerReviewModel();
            Rmodel.UserId = 1;

            return View(Rmodel);
        }

        //
        // POST: /AnswerReviews/Create
        [HttpPost]
        public ActionResult Create(AnswerReviewModel Rmodel)
        {
            try
            {
                AnswerReview _answerReview = new AnswerReview();
                _answerReview.IsApproved = Rmodel.IsApproved;
                _answerReview.IsReviewed = Rmodel.IsReviewed;
                _answerReview.QuestionAnswerId = Rmodel.QuestionAnswerId;
                _answerReview.Rating = Rmodel.Rating;
                _answerReview.ReplyText = Rmodel.ReplyText;
                _answerReview.ReviewText = Rmodel.ReviewText;
                _answerReview.Title = Rmodel.Title;
                _answerReview.UserId = Rmodel.UserId;
                _answerReview.CreatedOnUtc = DateTime.Now.ToUniversalTime();
                AnswerReviewBAL _answerReviewBAL = new AnswerReviewBAL();
                _answerReviewBAL.AddAnswerReview(_answerReview);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AnswerReviews/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }

        //
        // POST: /AnswerReviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AnswerReviews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AnswerReviews/Delete/5
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

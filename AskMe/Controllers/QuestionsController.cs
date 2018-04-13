
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Repository;
using Business.Interfaces;
using Data.AskUs;
using System.ComponentModel.DataAnnotations;
using AskMe.Models;
using CaptchaMvc.HtmlHelpers;
using System.IO;

namespace AskMe.Controllers
{
    public class QuestionsController : Controller
    { 
        //
        // GET: /Questions/
        [Display(Name="List Of Employees")]
        public ActionResult Index()
        {

            QuestionBAL questionBAL = new QuestionBAL();
            CategoryBAL _categoryBAL = new CategoryBAL();
            List<Question> _Qlist = questionBAL.GetAllQuestion();
            List<QuestionViewModel> _QlistModel = new List<QuestionViewModel>();

            foreach (var i in _Qlist)
            {
                var model = new QuestionViewModel();
                List<QuestionsCategory> _categorylist = _categoryBAL.GetAllCategory();
                foreach (var category in _categorylist)
                {
                    model.Category.Add(new SelectListItem
                    {
                        Text = category.Name,
                        Value = category.Id.ToString()
                    });
                }



                model.Id = i.Id;
                model.Title = i.Title;
                model.QuestionDetail = i.QuestionDetail;
                model.QuestionsCategoryId = i.QuestionsCategoryId;
                model.ServiceLocationId = i.ServiceLocationId;
                model.StatusId = i.StatusId;
                model.UserId = i.UserId;
                model.IsActive = i.IsActive==true?"True":"False";
                model.GetCall = (bool)i.GetCall;
                model.Notification = (bool)i.Notification;
                model.FilePath = i.FilePath;
                model.CreatedDate = i.CreatedDate;
                model.CreatedBy = i.CreatedBy;
                

                _QlistModel.Add(model);
            }
            return View(_QlistModel);

            
        }

        //
        // GET: /Questions/Details/5
        public ActionResult Details(long id)
        {
            var _question = new QuestionBAL();
           Question question= _question.GetQuestionById(id);
           var model = new QuestionViewModel();
           model.Id = question.Id;
           model.Title = question.Title;
           model.IsActive = question.IsActive.ToString();
           model.Notification = (bool)question.Notification;
           model.QuestionDetail = question.QuestionDetail;
           model.QuestionsCategoryId = question.QuestionsCategoryId;
           model.ServiceLocationId = question.ServiceLocationId;
           model.StatusId = question.StatusId;
           model.CreatedBy = question.CreatedBy;
           model.CreatedDate = question.CreatedDate;

           return View(model);

        }

        //
        // GET: /Questions/Create
        public ActionResult Create()
        {
            var model = new QuestionViewModel();
            model.Notification = true;
            model.GetCall = true;
            CategoryBAL _categoryBAL = new CategoryBAL();
            List<QuestionsCategory> category = _categoryBAL.GetAllCategory();
            foreach(var i in category)
            {
                model.Category.Add(new SelectListItem
                {
                    Text=i.Name,
                    Value=i.Id.ToString()
                });
            }            
            return View(model);
        }

        //
        // POST: /Questions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionViewModel model, HttpPostedFileBase file)
        {
            if ( this.IsCaptchaValid("Captcha is not valid")) //ModelState.IsValid &&
            { // Code for validating the CAPTCHA         

                // TODO: Add insert logic here   
                string saveToPath = string.Empty;
                if (file != null && file.ContentLength > 0)
                {
                    string imagesPath = HttpContext.Server.MapPath("~/QuestionsFiles"); // Or file save folder, etc.
                    string extension = Path.GetExtension(file.FileName);
                    string newFileName = $"NewFile{extension}";
                    saveToPath = Path.Combine(imagesPath, newFileName);
                    file.SaveAs(saveToPath);
                }                
                Question _question = new Question();
                _question.Title = model.Title;
                _question.QuestionDetail = model.QuestionDetail;
                _question.QuestionsCategoryId = model.QuestionsCategoryId;
                _question.ServiceLocationId = 1;
                _question.FilePath = saveToPath;
                _question.StatusId = 1;
                _question.Notification = model.Notification;
                _question.UserId = 1;
                _question.IsActive = true;
                _question.Published = true;
                _question.GetCall = model.GetCall;
                _question.CreatedBy = "Admin";
                _question.CreatedDate = DateTime.Now.ToUniversalTime();
                QuestionBAL _questonBAL = new QuestionBAL();
                _questonBAL.AddQuestion(_question);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrMessage = this.IsCaptchaValid("Captcha is not valid")==false?"Error: captcha is not valid.":"";              
                model.Notification = true;
                model.GetCall = true;
                CategoryBAL _categoryBAL = new CategoryBAL();
                List<QuestionsCategory> category = _categoryBAL.GetAllCategory();
                foreach (var i in category)
                {
                    model.Category.Add(new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
                }
                return View(model);
            }
        }

        //
        // GET: /Questions/Edit/5
        public ActionResult Edit(int id)
        {
            var _categoryBAL = new CategoryBAL();
            QuestionBAL _questionBAL = new QuestionBAL();
            Question _question = _questionBAL.GetQuestionById(id);
            var model = new QuestionViewModel();
            model.Id = _question.Id;
            model.Title = _question.Title;
            model.QuestionDetail = _question.QuestionDetail;
            model.QuestionsCategoryId = _question.QuestionsCategoryId;
            model.ServiceLocationId=_question.ServiceLocationId;
            model.StatusId=_question.StatusId;
            model.Notification=(bool)_question.Notification;
            model.GetCall=(bool)_question.GetCall;
            model.FilePath = _question.FilePath;
            model.CreatedBy = _question.CreatedBy;
            model.CreatedDate = _question.CreatedDate;
            model.IsActive = _question.IsActive == true ? "True" : "False";
            model.UserId = _question.UserId;
            
            List<QuestionsCategory> category = _categoryBAL.GetAllCategory();
            foreach (var i in category)
            {
                model.Category.Add(new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }

            return View(model);
        }

        //
        // POST: /Questions/Edit/5
        [HttpPost]
        public ActionResult Edit(long id, QuestionViewModel question)
        {
            try
            {
                // TODO: Add update logic here
                QuestionBAL _questionBAL= new QuestionBAL();
                Question _question = _questionBAL.GetQuestionById(id);

                _question.Title = question.Title;
                _question.QuestionDetail = question.QuestionDetail;
                _question.QuestionsCategoryId = question.QuestionsCategoryId;
                _question.Notification = question.Notification;
                _question.GetCall = question.GetCall;
                _question.ServiceLocationId = question.ServiceLocationId;
                _question.UpdatedBy = "Admin";
                _question.UpdatedDate = DateTime.Now.ToUniversalTime();
                _questionBAL.UpdateQuestion(_question);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Questions/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        //
        // POST: /Questions/Delete/5
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

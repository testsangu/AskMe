using AskMe.Models;
using Business.Repository;
using Data.AskUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AskMe.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
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
                model.IsActive = i.IsActive == true ? "True" : "False";
                model.GetCall = (bool)i.GetCall;
                model.Notification = (bool)i.Notification;
                model.FilePath = i.FilePath;
                model.CreatedDate = i.CreatedDate;
                model.CreatedBy = i.CreatedBy;


                _QlistModel.Add(model);
            }
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.QuestionViewModels = _QlistModel;
            return View(homeViewModel);
        }
        // GET: /Questions/Details/5
        //public ActionResult Details(int id)
        //{            
        //    return RedirectToAction("Details", "Questions",id);
        //}
    }
}

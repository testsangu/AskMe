using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Interfaces;
using Business.Repository;
using Data.AskUs;
using AskMe.Models;


namespace AskMe.Controllers
{
    public class QuestionsCategoryController : Controller
    {
        //
        // GET: /QuestionsCategory/
        public ActionResult Index()
        {
            CategoryBAL _catogery = new CategoryBAL();
            List<QuestionsCategory> _QCategory= _catogery.GetAllCategory();
            List<CategoryModel> _categoryModel = new List<CategoryModel>();

            foreach(var i in _QCategory)
            {
                var model = new CategoryModel();
                model.Id = i.Id;
                model.Name = i.Name;
                model.CreatedBy = "Admin";
                model.CreatedDate = DateTime.Now.ToUniversalTime();
                model.UpdatedBy = i.UpdatedBy;
                model.UpdatedDate = i.UpdatedDate;
                _categoryModel.Add(model);
            }
            return View(_categoryModel);
        }

        //
        // GET: /QuestionsCategory/Details/5
        public ActionResult Details(int id)
        {
            var _categoryBAL = new CategoryBAL();
            QuestionsCategory _QCategory = _categoryBAL.GetCategoryById(id);
            var model = new CategoryModel();
            model.Id = _QCategory.Id;
            model.Name = _QCategory.Name;
            model.IsActive = _QCategory.IsActive;
            model.CreatedBy = _QCategory.CreatedBy;
            model.CreatedDate = _QCategory.CreatedDate;


            return View(model);
        }

        //
        // GET: /QuestionsCategory/Create
        public ActionResult Create()
        {
            CategoryBAL _categoryBAL = new CategoryBAL();
            var model = new CategoryModel();


            return View(model);
        }

        //
        // POST: /QuestionsCategory/Create
        [HttpPost]
        public ActionResult Create(CategoryModel category)
        {
            try
            {
                // TODO: Add insert logic here
                CategoryBAL _categoryBAL = new CategoryBAL();
                QuestionsCategory _QCategory = new QuestionsCategory();
                _QCategory.Id = category.Id;
                _QCategory.Name = category.Name;
                _QCategory.CreatedBy = "Admin";
                _QCategory.CreatedDate = DateTime.Now.ToUniversalTime();
                _categoryBAL.AddQuestionCategory(_QCategory);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /QuestionsCategory/Edit/5
        public ActionResult Edit(int id)
        {
            var _categoryBAL = new CategoryBAL();
            QuestionsCategory _QCategory = _categoryBAL.GetCategoryById(id);
            var model = new CategoryModel();
            model.Id = _QCategory.Id;
            model.Name = _QCategory.Name;
            model.IsActive = _QCategory.IsActive;
            model.CreatedBy = _QCategory.CreatedBy;
            model.CreatedDate = _QCategory.CreatedDate;

            return View(model);
        }

        //
        // POST: /QuestionsCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryModel model)
        {
            try
            {
                // TODO: Add update logic here
                CategoryBAL _categogyBAL = new CategoryBAL();
                QuestionsCategory Qcategory = _categogyBAL.GetCategoryById(id);
                Qcategory.Id = model.Id;
                Qcategory.Name = model.Name;
                Qcategory.UpdatedBy = "Admin";
                Qcategory.UpdatedDate = DateTime.Now.ToUniversalTime();
                _categogyBAL.UpdateQuestionsCategory(Qcategory);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //
        // POST: /QuestionsCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoryModel model)
        {
            try
            {
                CategoryBAL _categoryBAL = new CategoryBAL();
                QuestionsCategory Qcategory = _categoryBAL.GetCategoryById(id);
                Qcategory.Id = model.Id;
                Qcategory.Name = model.Name;
                Qcategory.UpdatedBy = "Admin";
                Qcategory.UpdatedDate = DateTime.Now.ToUniversalTime();
                _categoryBAL.DeleteQuestoinsCategory(Qcategory);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

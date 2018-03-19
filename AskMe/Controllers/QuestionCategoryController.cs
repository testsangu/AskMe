using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AskMe.Controllers
{
    public class QuestionCategoryController : Controller
    {
        // GET: QuestionCategory
        public ActionResult Index()
        {
            return View();
        }

        // GET: QuestionCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuestionCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionCategory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionCategory/Edit/5
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

        // GET: QuestionCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionCategory/Delete/5
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

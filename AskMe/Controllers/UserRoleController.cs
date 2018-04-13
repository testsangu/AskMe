using Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Interfaces;
using Data.AskUs;
using AskMe.Models;

namespace AskMe.Controllers
{
    public class UserRoleController : Controller
    {
        //
        // GET: /UserRole/
        public ActionResult Index()
        {
            UserRoleBAL _userRole = new UserRoleBAL();
            List<UserRole> user = _userRole.GetAllUserRoles();
            List<UserRoleModel> _userRoleModel = new List<UserRoleModel>();
            foreach (var u in user)
            {
                var model = new UserRoleModel();
                model.RoleId = u.Id;
                model.RoleName = u.RoleName;
                model.IsActive = u.IsActive;
                model.CreatedBy = "Admin";
                model.CreatedDate = DateTime.Now.ToUniversalTime();
                _userRoleModel.Add(model);
            }
            return View(_userRoleModel);
        }

        //
        // GET: /UserRole/Details/5
        public ActionResult Details(int id)
        {


            return View();
        }

        //
        // GET: /UserRole/Create
        public ActionResult Create()
        {
            UserRoleBAL userRoleBAL = new UserRoleBAL();
            var model = new UserRoleModel();

            return View(model);
        }

        //
        // POST: /UserRole/Create
        [HttpPost]
        public ActionResult Create(UserRoleModel user)
        {
            try
            {
                UserRoleBAL _userRoleBAL = new UserRoleBAL();
                UserRole _userRole = new UserRole();
                _userRole.Id = user.RoleId;
                _userRole.RoleName = user.RoleName;
                _userRole.IsActive = user.IsActive;
                _userRole.CreatedBy = "Admin";
                _userRole.CreatedDate = DateTime.Now.ToUniversalTime();
                
                
                _userRoleBAL.AddUserRole(_userRole);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UserRole/Edit/5
        public ActionResult Edit(int id)
        {
            var _userRoleBAL = new UserRoleBAL();
            UserRole userRole = _userRoleBAL.GetUserRoleById(id);
            var model = new UserRoleModel();
            model.RoleId = userRole.Id;
            model.RoleName = userRole.RoleName;
            model.IsActive = userRole.IsActive;
            model.CreatedBy = "Admin";
            model.CreatedDate = DateTime.Now.ToUniversalTime();

            return View(model);
        }

        //
        // POST: /UserRole/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserRoleModel model)
        {
            try
            {
                UserRoleBAL _userRoleBAL = new UserRoleBAL();
                UserRole _userRole = _userRoleBAL.GetUserRoleById(id);
                _userRole.Id = model.RoleId;
                _userRole.RoleName = model.RoleName;
                _userRole.IsActive = model.IsActive;
                _userRole.CreatedBy = model.CreatedBy;
                _userRole.CreatedDate = model.CreatedDate;
                _userRoleBAL.UpdateUserRole(_userRole);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UserRole/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /UserRole/Delete/5
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

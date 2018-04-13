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
    public class UsersController : Controller
    {
        //
        // GET: /Users/
        public ActionResult Index()
        {
            UserBAL _userBAL = new UserBAL();
            List<User> Ulist = _userBAL.GetAllUsers();
            List<UserModel> _userModel = new List<UserModel>();

            foreach(var u in Ulist)
            {
                var model = new UserModel();
                model.Id = u.Id;
                model.UserName = u.UserName;
                model.Email = u.Email;
                model.Password = u.Password;
                model.IsActive = u.IsActive;
                model.IsDeleted = u.IsDeleted;
                model.PersonId = 1;
                //model.RewardPoints = u.RewardPoints;
                model.RoleId = u.RoleId;
                model.UpdatedDate = u.UpdatedDate;
                model.LawFirmId = u.LawFirmId;
                model.CreatedDate = DateTime.Now.ToUniversalTime();
                
                _userModel.Add(model);
            }
            return View(_userModel);
        }

        //
        // GET: /Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Users/Create
        public ActionResult Create()
        {
            var model = new UserModel();
            
            UserRoleBAL _userRoleBAL = new UserRoleBAL();
            List<UserRole> userRole = _userRoleBAL.GetAllUserRoles();
            foreach (var i in userRole)
            {
                model.Roles.Add (new SelectListItem
                {
                    Text = i.RoleName,
                    Value = i.Id.ToString()
                });
            }

            //var user = new QuestionModel();

            return View();
            
        }

        //
        // POST: /Users/Create
        [HttpPost]
        public ActionResult Create(UserModel  user)
        {
            try
            {
                // TODO: Add insert logic here
                User _user = new User();
                _user.Id= user.Id;
                _user.UserName=user.UserName;
                _user.Email=user.Email;
                _user.Password=user.Password;
                _user.LawFirmId=user.LawFirmId;
                //_user.PersonId = user.PersonId;
                _user.IsActive = true;
                _user.CreatedDate = DateTime.Now.ToUniversalTime();
                //_user.RewardPoints = user.RewardPoints;
                _user.IsDeleted = user.IsDeleted;
                _user.RoleId = user.RoleId;
                UserBAL _userBAL = new UserBAL();
                _userBAL.AddUsers(_user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Users/Edit/5
        public ActionResult Edit(int id)
        {
            UserBAL _userBAL = new UserBAL();
            User _user = _userBAL.GetUserById(id);
            var model = new UserModel();
            model.Id = _user.Id;
            model.UserName = _user.UserName;
            model.Email = _user.Email;
            model.Password = _user.Password;
            model.IsActive = true;
            model.LawFirmId = _user.LawFirmId;
            //model.PersonId = _user.PersonId;
            model.UpdatedDate = DateTime.Now.ToUniversalTime();
            model.IsDeleted = false;
            //model.RewardPoints = _user.RewardPoints;
            model.RoleId = _user.RoleId;
            model.CreatedDate = _user.CreatedDate;

            UserRoleBAL _userRoleBAL = new UserRoleBAL();
            List<UserRole> userRole = _userRoleBAL.GetAllUserRoles();
            foreach (var i in userRole)
            {
                model.Roles.Add(new SelectListItem
                {
                    Text = i.RoleName,
                    Value = i.Id.ToString()
                });
            }

            return View(model);
        }

        //
        // POST: /Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserModel user)
        {
            try
            {
                // TODO: Add update logic here
                UserBAL _userBAL = new UserBAL();
                User _user = _userBAL.GetUserById(id);
                _user.Id = user.Id;
                _user.UserName = user.UserName;
                _user.Email = user.Email;
                _user.Password = user.Password;
                _user.LawFirmId = user.LawFirmId;
                //_user.PersonId = user.PersonId;
                _user.RoleId = user.RoleId;
                _user.CreatedDate = user.CreatedDate;
                _user.IsActive = true;
                _user.IsDeleted = user.IsDeleted;
                //_user.RewardPoints = user.RewardPoints;
                _user.UpdatedDate = user.UpdatedDate;
                _userBAL.UpdateUser(_user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Users/Delete/5
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

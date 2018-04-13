using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Interfaces;
using Business.Repository;
using AskMe.Models;
using Data.AskUs;

namespace AskMe.Controllers
{
    public class ServiceLocationsController : Controller
    {
        
        public ActionResult Index()
        {
            ServiceLocationBAL _serviceLocationBAL = new ServiceLocationBAL();
            List<ServiceLocation> _serviceLocation = _serviceLocationBAL.GetAllLocation();
            List<ServiceLocationModel> _serviceLocationModel = new List<ServiceLocationModel>();

            foreach(var s in _serviceLocation)
            {
                var model = new ServiceLocationModel();
                model.Id = s.Id;
                model.Location = s.Location;
                model.State = s.State;
                model.City = s.City;
                model.Country = s.Country;
                model.Zipcode = s.Zipcode;
                model.IpAddress = s.IpAddress;
                _serviceLocationModel.Add(model);
            }

            return View(_serviceLocationModel);
        }

        //
        // GET: /ServiceLocations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ServiceLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ServiceLocations/Create
        [HttpPost]
        public ActionResult Create(ServiceLocationModel serviceLocation)
        {
            try
            {
                // TODO: Add insert logic here
                ServiceLocation _serviceLocation = new ServiceLocation();
                _serviceLocation.Id = serviceLocation.Id;
                _serviceLocation.Location = serviceLocation.Location;
                _serviceLocation.City = serviceLocation.City;
                _serviceLocation.State = serviceLocation.State;
                _serviceLocation.Country = serviceLocation.Country;
                _serviceLocation.Zipcode = serviceLocation.Zipcode;
                _serviceLocation.IpAddress = serviceLocation.IpAddress;

                ServiceLocationBAL _serviceLocationBAL = new ServiceLocationBAL();
                _serviceLocationBAL.AddServiceLocation(_serviceLocation);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ServiceLocations/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceLocationBAL _serviceLocationBAL = new ServiceLocationBAL();
            ServiceLocation _serviceLocation = _serviceLocationBAL.GetServiceLocationById(id);
            var model = new ServiceLocationModel();
            model.Id = _serviceLocation.Id;
            model.Location = _serviceLocation.Location;
            model.City = _serviceLocation.City;
            model.State = _serviceLocation.State;
            model.Country = _serviceLocation.Country;
            model.Zipcode = _serviceLocation.Zipcode;
            model.IpAddress = _serviceLocation.IpAddress;
            _serviceLocationBAL.UpdateServiceLocation(_serviceLocation);

            return View(model);
        }

        //
        // POST: /ServiceLocations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ServiceLocationModel serviceLocation)
        {
            try
            {
                // TODO: Add update logic here
                ServiceLocationBAL serviceLocationBAL = new ServiceLocationBAL();
                ServiceLocation _serviceLocation = serviceLocationBAL.GetServiceLocationById(id);
                _serviceLocation.Id = serviceLocation.Id;
                _serviceLocation.Location = serviceLocation.Location;
                _serviceLocation.City = serviceLocation.City;
                _serviceLocation.State = serviceLocation.State;
                _serviceLocation.Country = serviceLocation.Country;
                _serviceLocation.Zipcode = serviceLocation.Zipcode;
                _serviceLocation.IpAddress = serviceLocation.IpAddress;
                serviceLocationBAL.UpdateServiceLocation(_serviceLocation);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ServiceLocations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ServiceLocations/Delete/5
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Business.Interfaces;
using Data.AskUs;

namespace Business.Repository
{
    public class ServiceLocationBAL : IServiceLocationBAL
    {
        public List<ServiceLocation> GetAllLocation()
        {
            using (var _context = new AskUsDbContext())
            {
                List<ServiceLocation> SList = _context.ServiceLocations.ToList();
                return SList;
            }
        }

        public void AddServiceLocation(ServiceLocation  serviceLocation)
        {
            using(var _context= new AskUsDbContext())
            {
                _context.ServiceLocations.Add(serviceLocation);
                _context.SaveChanges();
            }
        }




        public ServiceLocation GetServiceLocationById(int id)
        {
            using(var _context = new AskUsDbContext())
            {
                ServiceLocation serviceLocation = _context.ServiceLocations.Where(x => x.Id == id).FirstOrDefault();
                return serviceLocation;
            }
        }

        public void UpdateServiceLocation(ServiceLocation serviceLocation)
        {
            using(var _context= new AskUsDbContext())
            {
                _context.Entry(serviceLocation).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}

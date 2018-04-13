using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Repository;
using Data;
using Data.AskUs;

namespace Business.Repository
{
    public class UserRoleBAL : IUserRoleBAL
    {


        public void AddUserRole(UserRole role)
        {
       
            using(var _context= new AskUsDbContext())
            {
               UserRole userRole = _context.UserRoles.Add(role);
                _context.SaveChanges();
            }
        }

       public UserRole GetUserRoleById(int id)
        {
           using(var _context= new AskUsDbContext())
           {
               UserRole role = _context.UserRoles.Where(x => x.Id == id).FirstOrDefault();
               return role;
           }
        }
       public List<UserRole> GetAllUserRoles()
       {
           using(var _context= new AskUsDbContext())
           {
               List<UserRole> usersRole = _context.UserRoles.ToList();
               return usersRole;
           }
       }
        public void UpdateUserRole(UserRole userRole)
       {
           using(var _context= new AskUsDbContext())
           {
               _context.Entry(userRole).State = System.Data.Entity.EntityState.Modified;
               _context.SaveChanges();
           }
       }

      
    }

    
}

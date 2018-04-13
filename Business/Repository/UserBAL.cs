using Business.Interfaces;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.AskUs;

namespace Business.Repository
{
    public class UserBAL : IUserBAL
    {
        public List<User> GetAllUsers()
        {
            using(var _context= new AskUsDbContext())
            {
                List<User> userList = _context.Users.ToList();
                return userList;
            }
        }
        public void AddCustomer(User user)
        {
            using (var _context = new AskUsDbContext())
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }
        public void AddUsers(User user)
        {
            using(var _context= new AskUsDbContext())
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public User GetUserById(int id)
        {
            using(var _context= new AskUsDbContext())
            {
                User user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
                return user;
            }
        }

        public void UpdateUser(User user)
        {
            using(var _context= new AskUsDbContext())
            {
                _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public bool RegsterCustomer(Customer _customer,User _user)
        {
            using (var _context = new AskUsDbContext())
            {
                _context.Customers.Add(_customer);
                _context.SaveChanges();
                _user.CustomerId = _customer.Id;
                _context.Users.Add(_user);
                _context.SaveChanges();
                return true;
            }
        }

        public User Login(string _emailid,string _password)
        {
            using (var _context = new AskUsDbContext())
            {
                User user = _context.Users.Where(x => x.Email== _emailid && x.Password==_password).FirstOrDefault();
                return user;
            }
        }

        public Customer GetCustomer(int _customerId)
        {
            using (var _context = new AskUsDbContext())
            {
                Customer _customer = _context.Customers.Where(x => x.Id== _customerId).FirstOrDefault();
                return _customer;
            }
        }
    }
}

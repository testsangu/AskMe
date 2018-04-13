using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.AskUs;

namespace Business.Interfaces
{
     interface IUserBAL 
    {
        List<User> GetAllUsers();
        void AddUsers(User user);
        User GetUserById(int id);
        void UpdateUser(User user);
        bool RegsterCustomer(Customer _customer, User _user);
        User Login(string _emailid, string _password);
        Customer GetCustomer(int _customerId);
        //int Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.AskUs;

namespace Business.Interfaces
{
    interface IUserRoleBAL 
    {
        void AddUserRole(UserRole role);
        UserRole GetUserRoleById(int id);
        List<UserRole> GetAllUserRoles();
        void UpdateUserRole(UserRole role);
        //bool Delete(int id);
    }
}

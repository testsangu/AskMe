using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskMe.Models
{
    public class UserRoleModel
    {
        public int RoleId { get; set; } 
        public string RoleName { get; set; }  
        public bool IsActive { get; set; } 
        public string CreatedBy { get; set; } 
        public System.DateTime CreatedDate { get; set; } 
    }
}
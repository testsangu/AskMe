using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.AskUs;

namespace Business.Interfaces
{
    interface IAddress 
    {
        List<Address> GetAllAddress();
        void AddAddress(Address address);

        Address GetAddressById(int id);
        void DeleteAddress(Address address);
    }
}

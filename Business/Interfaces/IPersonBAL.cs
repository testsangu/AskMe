using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.AskUs;

namespace Business.Interfaces
{
    interface IPersonBAL 
    {
        int Create(Person person);
        Person GetById(int id);
        List<Person> GetAllPerson();
        bool Update(Person person);
        bool Delete(int id);
    }
}

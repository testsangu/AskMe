using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.AskUs;

namespace Business.Interfaces
{
    interface IServiceLocationBAL
    {
        List<ServiceLocation> GetAllLocation();

        void AddServiceLocation(ServiceLocation serviceLocation);
        ServiceLocation GetServiceLocationById(int id);

        void UpdateServiceLocation(ServiceLocation serviceLocation);
        
    }
}

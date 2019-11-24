using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrabData.Services
{
    public interface IGrabService
    {
        Task GetVehicles(string agency, string route);
        Task GetVehicle(string agency, string route);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrabData.Services
{
    public class GrabService : IGrabService
    {
        private IRawService _rawService;
        private Dictionary<string, List<string>> _routeVehicles;
        public GrabService(IRawService rawService)
        {
            _rawService = rawService;
            _routeVehicles = new Dictionary<string, List<string>>();
        }

        public async Task GetVehicles(string agency, string route)
        {
            await Task.Delay(0);
        }

        public async Task GetVehicle()
        {
            await Task.Delay(0);
            // get list

            // save new objects from list 
            // delete old ones and log that
            // for each item get

        }
    }
}

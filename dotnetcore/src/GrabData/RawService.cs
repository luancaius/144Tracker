using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrabData
{
    public class RawService
    {
        private readonly INextBusApi _nextBusApi;
        public RawService()
        {
            _nextBusApi = RestService.For<INextBusApi>("http://webservices.nextbus.com/service/publicJSONFeed");
        }
        public async Task<List<string>> IndexRouteVehicles(string agency, string route)
        {
            try
            {
                var apiResponse = await _nextBusApi.GetRouteVehicles("vehicleLocations", agency, route, "0");
                var vehicleIds = apiResponse.VehicleList.Select(a => a.VehicleId).ToList();
                return vehicleIds;
            }
            catch (ValidationApiException validationException)
            {
                // handle validation here by using validationException.Content, 
                // which is type of ProblemDetails according to RFC 7807
            }
            catch (ApiException exception)
            {
                // other exception handling
            }
            return null;
        }

        public async Task IndexRouteVehicle(string agency, string route, HashSet<string> vehicleIds)
        {
            if (!vehicleIds.Any())
            {
                Console.WriteLine("No vehicles to search!");    
                return;
            }   
            try
            {
                Console.WriteLine();
                var tasks = new List<Task<Vehicle>>();
                foreach (var vehicleId in vehicleIds)
                {
                    tasks.Add(_nextBusApi.GetRouteVehicle("vehicleLocations", agency, route, "0", vehicleId));    
                }

                var listVehicles = await Task.WhenAll(tasks);

                var count = listVehicles.Length;
            }
            catch (ValidationApiException validationException)
            {
                // handle validation here by using validationException.Content, 
                // which is type of ProblemDetails according to RFC 7807
            }
            catch (ApiException exception)
            {
                // other exception handling
            }
        }
    }
}

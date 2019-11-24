using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Repository.Interfaces;
using GrabData.Refit;
using GrabData.Models;

namespace GrabData.Services
{
    public class RawService : IRawService
    {
        private readonly INextBusApi _nextBusApi;
        public RawService(IRepository<Repository.Models.Vehicle> repository)
        {
            _nextBusApi = RestService.For<INextBusApi>("http://webservices.nextbus.com/service/publicJSONFeed");
        }

        public async Task<List<Vehicle>> GetVehicles(string agency, string route)
        {
            try
            {
                Console.WriteLine($"Start GetVehicles {agency} {route}");
                var apiResponse = await _nextBusApi.GetRouteVehicles("vehicleLocations", agency, route, "0");
                var vehicles = apiResponse.VehicleList;
                PrintVehicles(vehicles);
                Console.WriteLine($"End GetVehicles {agency} {route}: {(vehicles == null ? 0 : vehicles.Count)} vehicles");
                return vehicles;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception GetVehicles: {e.Message}");
            }
            return null;
        }

        public async Task<Vehicle> GetVehicle(string agency, string route, string vehicleId)
        {
            try
            {
                Console.WriteLine($"Start GetVehicle {agency} {route} {vehicleId}");
                var vehicleResponse = await _nextBusApi.GetRouteVehicle("vehicleLocation", agency, route, "0", vehicleId);
                return vehicleResponse.Vehicle;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception GetVehicles: {e.Message}");
            }
            return null;
        }

        private void PrintVehicles(List<Vehicle> vehicles)
        {
            if (vehicles != null)
            {
                foreach(var vehicle in vehicles)
                {
                    Console.WriteLine($"VehicleId: {vehicle.VehicleId}");
                }
            }
        }
    }
}

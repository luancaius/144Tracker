using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Provider.NextBus.Models;
using Refit;

namespace Provider.NextBus
{
    public class RawService : IRawService
    {
        private readonly INextBusApi _nextBusApi;
        public RawService()
        {
            _nextBusApi = RestService.For<INextBusApi>("http://webservices.nextbus.com/service/publicJSONFeed");
        }

        Task<Vehicle> IRawService.GetVehicle(string agency, string route, string vehicleId)
        {
            return GetVehicle(agency, route, vehicleId);
        }

        Task<List<Vehicle>> IRawService.GetVehicles(string agency, string route)
        {
            return GetVehicles(agency, route);
        }

        public async Task<List<Vehicle>> GetVehicles(string agency, string route)
        {
            try
            {
                var apiResponse = await _nextBusApi.GetRouteVehicles("vehicleLocations", agency, route, "0");
                var vehicles = apiResponse.VehicleList;
                return vehicles;
            }
            catch (Exception e)
            {
            }
            return null;
        }

        public async Task<BusStopSet> GetBusStops(string agency, string route)
        {
            try
            {
                var busStops = await _nextBusApi.GetBusStops("routeConfig", agency, route);
                return busStops;
            }
            catch (Exception e)
            {
            }
            return null;  
        }

        public async Task<Vehicle> GetVehicle(string agency, string route, string vehicleId)
        {
            try
            {
                var vehicleResponse = await _nextBusApi.GetRouteVehicle("vehicleLocation", agency, route, "0", vehicleId);
                return vehicleResponse.Vehicle;
            }
            catch (Exception e)
            {
            }
            return null;
        }
    }
}

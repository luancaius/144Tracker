using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Provider.NextBus;
using Provider.NextBus.Mappers;

namespace Service
{
    public class Service : IService
    {
        private IRawService _rawService;
        public Service(IRawService rawService)
        {
            _rawService = rawService;
        }
        public async Task<List<BusStop>> GetBusStopList(string agency, string route, double? lat, double? lon)
        {
            var busStopSet = await _rawService.GetBusStops(agency, route);
            return busStopSet?.BusStops.Select(a => a.ConvertToDomain(lat, lon)).OrderBy(a => a.Distance).Take(5).ToList();
        }
        
        public async Task<List<Vehicle>> GetVehicleList(string agency, string route, double lat, double lon)
        {
            var vehicles = await _rawService.GetVehicles(agency, route);
            return vehicles?.Select(a => a.ConvertToDomain(lat, lon)).OrderBy(a => a.DistanceFromBusStop).Take(5).ToList();
        }

        public Task<List<Prediction>> GetPredictions(string agency, string route, string vehicleId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BusScheduleDay> GetBusSchedule(string agency, string route, string busStopId)
        {
            var vehicles = await _rawService.GetScheduleDay(agency, route);
            return new BusScheduleDay();
        }
    }
}
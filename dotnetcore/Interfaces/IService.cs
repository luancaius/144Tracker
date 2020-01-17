using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModel;

namespace Service
{
    public interface IService
    {
        Task<List<BusStop>> GetBusStopList(string agency, string route, double? lat, double? lon);
        Task<List<Vehicle>> GetVehicleList(string agency, string route, double lat, double lon);
        Task<List<Prediction>> GetPredictions(string agency, string route, string vehicleId);
        Task<BusSchedule> GetBusSchedule(string agency, string route, string busStopId);
    }
}
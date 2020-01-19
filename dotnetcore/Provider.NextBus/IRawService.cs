using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModel;
using Provider.NextBus.Models;
using Vehicle = Provider.NextBus.Models.Vehicle;

namespace Provider.NextBus
{
    public interface IRawService
    {
        Task<BusStopSet> GetBusStops(string agency, string route);
        Task<Vehicle> GetVehicle(string agency, string route, string vehicleId);
        Task<List<Vehicle>> GetVehicles(string agency, string route);
        Task<BusScheduleDay> GetScheduleDay(string agency, string route);
    }
}
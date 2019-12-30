using System.Collections.Generic;
using System.Threading.Tasks;
using Provider.NextBus.Models;

namespace Provider.NextBus
{
    public interface IRawService
    {
        Task<BusStopSet> GetBusStops(string agency, string route);
        Task<Vehicle> GetVehicle(string agency, string route, string vehicleId);
        Task<List<Vehicle>> GetVehicles(string agency, string route);
    }
}
using System.Threading.Tasks;
using Provider.NextBus.Models;
using Refit;

namespace Provider.NextBus
{
    public interface INextBusApi
    {
        [Get("")]
        Task<string> GetBusStops([AliasAs("command")] string command, [AliasAs("a")] string agency, [AliasAs("r")] string route);
        [Get("")]
        Task<Vehicles> GetRouteVehicles([AliasAs("command")] string command, [AliasAs("a")] string agency, 
            [AliasAs("r")] string route, [AliasAs("t")] string timeInEpochMs);
        [Get("")]
        Task<VehicleResponse> GetRouteVehicle([AliasAs("command")] string command, [AliasAs("a")] string agency, 
            [AliasAs("r")] string route, [AliasAs("t")] string timeInEpochMs, [AliasAs("v")] string vehicleId);
    }
}
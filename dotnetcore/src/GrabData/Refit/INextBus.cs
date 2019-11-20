using GrabData.Models;
using Refit;
using System.Threading.Tasks;

namespace GrabData.Refit
{
    public interface INextBusApi
    {
        [Get("")]
        Task<Vehicles> GetRouteVehicles([AliasAs("command")] string command, [AliasAs("a")] string agency, 
                                        [AliasAs("r")] string route, [AliasAs("t")] string timeInEpochMs);
        [Get("")]
        Task<VehicleResponse> GetRouteVehicle([AliasAs("command")] string command, [AliasAs("a")] string agency, 
                                      [AliasAs("r")] string route, [AliasAs("t")] string timeInEpochMs, [AliasAs("v")] string vehicleId);
    }
}

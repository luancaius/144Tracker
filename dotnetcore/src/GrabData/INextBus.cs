using Refit;
using System.Threading.Tasks;

namespace GrabData
{
    public interface INextBusApi
    {
        [Get("")]
        Task<Vehicles> GetRouteVehicles([AliasAs("command")] string command, [AliasAs("a")] string agency, 
                                        [AliasAs("r")] string route, [AliasAs("t")] string timeInEpochMs);
        [Get("")]
        Task<Vehicle> GetRouteVehicle([AliasAs("command")] string command, [AliasAs("a")] string agency, 
                                      [AliasAs("r")] string route, [AliasAs("t")] string timeInEpochMs, 
                                     [AliasAs("v")] string vehicleId);
    }
}

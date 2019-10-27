using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrabData
{
    public interface IRawService
    {
        Task<List<string>> IndexRouteVehicles(string agency, string route);
        Task IndexRouteVehicle(string agency, string route, HashSet<string> vehicleIds);
    }
}
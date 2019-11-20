using GrabData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrabData.Services
{
    public interface IRawService
    {
        Task<Vehicle> GetVehicle(string agency, string route, string vehicleId);
        Task<List<Vehicle>> GetVehicles(string agency, string route);
    }
}
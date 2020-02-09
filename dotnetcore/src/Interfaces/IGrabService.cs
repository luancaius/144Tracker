using System.Threading.Tasks;

namespace Interfaces
{
    public interface IGrabService
    {
        Task GetVehicles(string agency, string route);
    }
}

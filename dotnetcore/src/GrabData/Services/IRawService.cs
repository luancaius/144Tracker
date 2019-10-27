using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrabData.Services
{
    public interface IRawService
    {
        Task Execute(string agency, string route);
    }
}
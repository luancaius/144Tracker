using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrabData
{
    public interface INextBusApi
    {
        [Get("")]
        Task<ApiResponse> GetVehicleLocations([AliasAs("command")] string command, [AliasAs("a")] string agency, [AliasAs("r")] string route, [AliasAs("t")] string timeInEpochMs);
    }

    public class ApiResponse
    {
        [JsonProperty("vehicle")]        
        public List<RouteBusList> Vehicles { get; set; }
    }
}

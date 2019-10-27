using System.Collections.Generic;
using Newtonsoft.Json;

namespace GrabData
{
    public class Vehicles
    {
        [JsonProperty("vehicle")]        
        public List<Vehicle> VehicleList { get; set; }
    }
}
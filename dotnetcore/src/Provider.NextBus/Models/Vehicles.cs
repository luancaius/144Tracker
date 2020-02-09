using System.Collections.Generic;
using Newtonsoft.Json;

namespace Provider.NextBus.Models
{
    public class Vehicles
    {
        [JsonProperty("vehicle")]        
        public List<Vehicle> VehicleList { get; set; }
    }
}
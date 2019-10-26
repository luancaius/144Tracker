using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrabData
{
    public class RouteBusList
    {
        [JsonProperty("id")]
        public string BusId { get; set; }
        [JsonProperty("routeTag")]
        public string Route { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("secsSinceReport")]
        public int SecondsSinceReport { get; set; }
        [JsonProperty("heading")]
        public int Heading { get; set; }        
        public string dirTag { get; set; }
        [JsonProperty("predictable")]
        public bool Predictable { get; set; }
    }
}

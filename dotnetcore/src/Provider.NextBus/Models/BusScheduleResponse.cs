using Newtonsoft.Json;

namespace Provider.NextBus.Models
{
    public class BusScheduleResponse
    {
        [JsonProperty("route")]
        public BusScheduleType[] BusScheduleTypes { get; set; }
        [JsonProperty("copyright")]
        public string Copyright { get; set; }    
    }
}
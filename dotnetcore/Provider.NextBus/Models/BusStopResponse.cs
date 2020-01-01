using Newtonsoft.Json;

namespace Provider.NextBus.Models
{
    public class BusStopResponse
    {
        [JsonProperty("route")]
        public BusStopSet BusStopSet { get; set; }
        [JsonProperty("copyright")]
        public string Copyright { get; set; }    }
}
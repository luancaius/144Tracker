using System.Collections.Generic;
using Newtonsoft.Json;

namespace Provider.NextBus.Models
{
    public class BusStopSet
    {
        [JsonProperty("latMax")]
        public double LatMax { get; set; }
        [JsonProperty("lonMax")]
        public double LonMax { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("stop")]
        public List<BusStop> BusStops { get; set; }
        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}

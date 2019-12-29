using Newtonsoft.Json;

namespace Provider.NextBus.Models
{
    public class BusStop
    {
        [JsonProperty("stopId")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}

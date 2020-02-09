using Newtonsoft.Json;

namespace Provider.NextBus.Models
{
    public class BusScheduleContent
    {
        [JsonProperty("content")]
        public string Time { get; set; }
        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}
using Newtonsoft.Json;

namespace Provider.NextBus.Models
{
    public class BusScheduleType
    {
        [JsonProperty("serviceClass")]
        public string ServiceClass { get; set; }
        [JsonProperty("direction")]
        public string Direction { get; set; }
        [JsonProperty("tag")]
        public string Tag { get; set; }
        [JsonProperty("scheduleClass")]
        public string ScheduleClass { get; set; }
        [JsonProperty("tr")]
        public BusScheduleBlock[] BlockSet { get; set; }
    }
}
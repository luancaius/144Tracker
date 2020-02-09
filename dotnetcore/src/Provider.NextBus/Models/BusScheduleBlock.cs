using Newtonsoft.Json;

namespace Provider.NextBus.Models
{
    public class BusScheduleBlock
    {
        [JsonProperty("stop")]
        public BusScheduleContent[] BusScheduleStops { get; set; }
        [JsonProperty("blockID")]
        public string BlockId { get; set; }
    }
}
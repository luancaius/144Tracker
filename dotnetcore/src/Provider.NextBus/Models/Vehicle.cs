﻿using Newtonsoft.Json;

namespace Provider.NextBus.Models
{
    public class Vehicle
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("routeTag")]
        public string Route { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("secsSinceReport")]
        public int SecondsSinceReport { get; set; }
    }
}

using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrabData.Models
{
    public class Vehicle
    {
        [JsonProperty("id")]
        public string VehicleId { get; set; }
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
        [JsonProperty("dirTag")]
        public string DirTag { get; set; }
        [JsonProperty("predictable")]
        public bool Predictable { get; set; }

        public static Repository.Models.Vehicle ConvertFrom(Vehicle vehicle)
        {
            var vehicleDTO = new Repository.Models.Vehicle();
            vehicleDTO.Id = vehicle.VehicleId;
            vehicleDTO.Latitude = vehicle.Latitude;
            vehicleDTO.Longitude = vehicle.Longitude;
            vehicleDTO.Route = vehicle.Route;
            vehicleDTO.Heading = vehicle.Heading;
            vehicleDTO.DirTag = vehicle.DirTag;
            vehicleDTO.Date = DateTime.Now;
            return vehicleDTO;
        }
    }
}

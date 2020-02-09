using Nest;
using System;

namespace Repository.Models
{
    public class Vehicle
    {        
        public string VehicleId { get; set; }
        public string Route { get; set; }
        public GeoLocation Location { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Date:{Date} - VehicleId:{VehicleId} - Route:{Route} - Lat:{Location.Latitude} - Lon:{Location.Longitude}";
        }
        
        public static Repository.Models.Vehicle ConvertFrom(DomainModel.Vehicle vehicle)
        {
            var vehicleDTO = new Repository.Models.Vehicle();
            vehicleDTO.VehicleId = vehicle.Id;
            vehicleDTO.Location = new GeoLocation(vehicle.Latitude, vehicle.Longitude);
            vehicleDTO.Route = vehicle.Route;
            vehicleDTO.Date = DateTime.Now;
            return vehicleDTO;
        }
    }
}
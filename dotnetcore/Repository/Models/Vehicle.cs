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
        public int Heading { get; set; }        
        public string DirTag { get; set; }

        public override string ToString()
        {
            return $"Date:{Date} - VehicleId:{VehicleId} - Route:{Route} - Lat:{Location.Latitude} - Lon:{Location.Longitude}";
        }
    }
}
using System;

namespace Repository.Models
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string Route { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public int Heading { get; set; }        
        public string DirTag { get; set; }
    }
}
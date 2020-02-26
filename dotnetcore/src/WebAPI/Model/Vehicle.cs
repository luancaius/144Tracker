using System;

namespace WebAPI.Model
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string Route { get; set;}
        public double Latitude { get; set;}
        public double Longitude { get; set;}
        public int SecondsSinceReport { get; set;}
        public string Distance { get; set;}
        public DateTime CreatedOn { get; set; }

        public override string ToString()
        {
            return $"{Route}|{Id}";
        }
    }
}
using System;

namespace DomainModel
{
    public class Vehicle
    {
        public string Id { get; }
        public string Route { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public int SecondsSinceReport { get; }
        public double DistanceFromBusStop { get; }

        public Vehicle(string id, string route, double lat, double lon, int secondsSinceReport, double distanceFromBusStop)
        {
            Id = id;
            Route = route;
            Latitude = lat;
            Longitude = lon;
            SecondsSinceReport = secondsSinceReport;
            DistanceFromBusStop = distanceFromBusStop;
        }
    }
}
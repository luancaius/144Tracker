namespace DomainModel
{
    public class Vehicle
    {
        public string Id { get; }
        public string Route { get; }
        public double Lat { get; }
        public double Lon { get; }
        public int SecondsSinceReport { get; }

        public Vehicle(string id, string route, double lat, double lon, int secondsSinceReport)
        {
            Id = id;
            Route = route;
            Lat = lat;
            Lon = lon;
            SecondsSinceReport = secondsSinceReport;
        }
    }
}
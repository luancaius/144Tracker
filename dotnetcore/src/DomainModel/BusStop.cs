namespace DomainModel
{
    public class BusStop
    {
        public string Id { get; }
        public string Title { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public string  Tag { get; }
        public double Distance { get; }

        public BusStop(string id, string title, double lat, double lon, string tag, double distance)
        {
            Id = id;
            Title = title;
            Latitude = lat;
            Longitude = lon;
            Tag = tag;
            Distance = distance;
        }
    }
}

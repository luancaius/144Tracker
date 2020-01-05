namespace DomainModel
{
    public class BusStop
    {
        public string Id { get; }
        public string Title { get; }
        public double Lat { get; }
        public double Lon { get; }
        public string  Tag { get; }
        public double Distance { get; }

        public BusStop(string id, string title, double lat, double lon, string tag, double distance)
        {
            Id = id;
            Title = title;
            Lat = lat;
            Lon = lon;
            Tag = tag;
            Distance = distance;
        }
    }
}

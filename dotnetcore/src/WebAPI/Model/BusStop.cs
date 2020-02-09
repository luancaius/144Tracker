namespace WebAPI.Model
{
    public class BusStop
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Distance { get; set; }
    }
}
namespace WebAPI.Mapper
{
    public static class Mapping
    {
        public static Model.BusStop ConvertFromDomain(DomainModel.BusStop source)
        {
            var destin = new Model.BusStop();
            destin.Id = source.Id;
            destin.Title = source.Title;
            destin.Latitude = source.Lat;
            destin.Longitude = source.Lon;
            destin.Distance = source.Distance.ToString("N2");
            return destin;
        }
    }
}
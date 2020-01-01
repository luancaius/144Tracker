using Provider.NextBus.Models;

namespace Provider.NextBus.Mappers
{
    public static class Extension
    {
        public static DomainModel.BusStop ConvertToDomain(this BusStop source)
        {
            var domain = new DomainModel.BusStop(source.Id, source.Title, source.Latitude, source.Longitude, source.Tag);
            return domain;
        }
    }
}
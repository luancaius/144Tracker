using GeoCoordinatePortable;
using Provider.NextBus.Models;
namespace Provider.NextBus.Mappers
{
    public static class Extension
    {
        public static DomainModel.BusStop ConvertToDomain(this BusStop source, double? lat, double? lon)
        {
            var distance = -1.0d;
            if (lat.HasValue && lon.HasValue)
            {
                var origin = new GeoCoordinate(lat.Value, lon.Value);
                var destin = new GeoCoordinate(source.Latitude, source.Longitude);
                distance = origin.GetDistanceTo(destin);
            }
            var domain = new DomainModel.BusStop(source.Id, source.Title, source.Latitude, source.Longitude, source.Tag, distance);
            return domain;
        }
    }
}
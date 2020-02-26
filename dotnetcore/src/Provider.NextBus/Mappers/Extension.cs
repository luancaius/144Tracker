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
        
        public static DomainModel.Vehicle ConvertToDomain(this Vehicle vehicle, double lat, double lon)
        {
            var origin = new GeoCoordinate(lat, lon);
            var destin = new GeoCoordinate(vehicle.Latitude, vehicle.Longitude);
            var distance = origin.GetDistanceTo(destin);
            
            var vehicleDomain = new DomainModel.Vehicle(vehicle.Id, vehicle.Route, vehicle.Latitude, vehicle.Longitude, vehicle.SecondsSinceReport, distance);
            return vehicleDomain;
        }

        public static DomainModel.Vehicle ConvertToDomain(this Vehicle vehicle)
        {
            var vehicleDomain = new DomainModel.Vehicle(vehicle.Id, vehicle.Route, vehicle.Latitude, vehicle.Longitude, vehicle.SecondsSinceReport, -1);
            return vehicleDomain;
        }
    }
}
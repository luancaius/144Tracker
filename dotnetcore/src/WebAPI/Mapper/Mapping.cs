using System;

namespace WebAPI.Mapper
{
    public static class Mapping
    {
        public static Model.BusStop ConvertFromDomain(DomainModel.BusStop source)
        {
            var destin = new Model.BusStop();
            destin.Id = source.Id;
            destin.Title = source.Title;
            destin.Latitude = source.Latitude;
            destin.Longitude = source.Longitude;
            destin.Distance = source.Distance.ToString("N0");
            return destin;
        }

        public static Model.Vehicle ConvertFromDomain(DomainModel.Vehicle source)
        {
            var destin = new Model.Vehicle();
            destin.Id = source.Id;
            destin.Route = source.Route;
            destin.Latitude = source.Latitude;
            destin.Longitude = source.Longitude;
            destin.SecondsSinceReport = source.SecondsSinceReport;
            destin.Distance = source.DistanceFromBusStop.ToString("N0");
            destin.CreatedOn = DateTime.Now;
            return destin;
        }
    }
}
using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrabData
{
    public class RouteBusList
    {
        [AliasAs("id")]
        public int BusId { get; set; }
        [AliasAs("routeTag")]
        public string Route { get; set; }
        [AliasAs("lat")]
        public double Latitude { get; set; }
        [AliasAs("lon")]
        public double Longitude { get; set; }
        [AliasAs("secsSinceReport")]
        public int SecondsSinceReport { get; set; }
        [AliasAs("heading")]
        public int Heading { get; set; }
    }
}

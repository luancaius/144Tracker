using System;
using System.Collections.Generic;

namespace DomainModel
{
    public class BusSchedule
    {
        public string BusStopId { get; }
        public string Route { get; }
        public Dictionary<int, List<TimeSpan>> BusTimeByDay { get; }
    }
}
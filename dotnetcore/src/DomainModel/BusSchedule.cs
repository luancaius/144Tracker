using System;
using System.Collections.Generic;

namespace DomainModel
{
    public class BusScheduleDay
    {
        public string BusStopId { get; }
        public string Route { get; }
        public List<TimeSpan> BusTime { get; }
    }
}
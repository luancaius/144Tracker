using System;
using System.Collections.Generic;

namespace WebAPI.Model
{
    public class BusSchedule
    {
        public string BusStopId { get; }
        public string Route { get; }
        public List<TimeSpan> BusTime { get; }
    }
}
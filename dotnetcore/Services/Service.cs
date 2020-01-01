using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Provider.NextBus;
using Provider.NextBus.Mappers;

namespace Service
{
    public class Service : IService
    {
        private IRawService _rawService;
        public Service(IRawService rawService)
        {
            _rawService = rawService;
        }
        public async Task<List<BusStop>> GetBusStopList(string agency, string route)
        {
            var busStopSet = await _rawService.GetBusStops(agency, route);
            return busStopSet?.BusStops.Select(a => a.ConvertToDomain()).ToList();
        }
    }
}
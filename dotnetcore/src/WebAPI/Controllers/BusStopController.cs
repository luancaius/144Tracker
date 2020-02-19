using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using Service;
using WebAPI.Mapper;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusStopController : ControllerBase
    {
        private IService _service;
        private ILogger<BusStopController> _logger;
        public BusStopController(IService service, ILogger<BusStopController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<List<BusStop>>> Get(string agency, string route, double? latitude, double? longitude)
        {
            _logger.LogTrace($"Get Bustop from {agency} {route}");
            var busStopsDomain = await _service.GetBusStopList(agency, route, latitude, longitude);
            var busStops = busStopsDomain.Select(Mapping.ConvertFromDomain).ToList();
            return Ok(busStops);
        }
        
        [HttpGet("{id}")]
        public ActionResult<BusStop> GetBusStop(int id)
        {
            return Ok(new BusStop
            {
                Id = "1",
                Distance = "10"
            });
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Service;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusStopController : ControllerBase
    {
        private IService _service;
        public BusStopController(IService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<BusStop>> Get(string agency, string route, double? latitude, double? longitude)
        {
            var busStops = _service.GetBusStopList(agency, route);
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
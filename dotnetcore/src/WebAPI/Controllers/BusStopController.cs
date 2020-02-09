using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public BusStopController(IService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<BusStop>>> Get(string agency, string route, double? latitude, double? longitude)
        {
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
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
    public class PredictionController : ControllerBase
    {
        private IService _service;
        public PredictionController(IService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Prediction>>> Get(string agency, string route, double? latitude, double? longitude)
        {
            var busStopsDomain = await _service.GetBusStopList(agency, route, latitude, longitude);
            var busStops = busStopsDomain.Select(Mapping.ConvertFromDomain).ToList();
            return Ok(busStops);
        }
    }
}
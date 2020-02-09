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
    public class ScheduleController : ControllerBase
    {
        private IService _service;
        public ScheduleController(IService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<BusSchedule>>> Get(string agency, string route, string busStopId)
        {
            var busScheduleDayDomain = await _service.GetBusSchedule(agency, route, busStopId);
            //var busStops = busStopsDomain.Select(Mapping.ConvertFromDomain).ToList();
            return Ok(busScheduleDayDomain);
        }
    }
}
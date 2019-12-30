using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusStopController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<BusStop>> GetAll(string agency, string route, double? latitude, double? longitude)
        {
            return Ok(new List<BusStop>{new BusStop
            {
                Id = "1",
                Distance = "10",
                Title = $"agency {agency} \troute {route}",
                Latitude = latitude ?? 10.0,
                Longitude = longitude ?? 11.0
            }});
        }
    }
}
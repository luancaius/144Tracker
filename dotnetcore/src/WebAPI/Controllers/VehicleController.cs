using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using Service;
using WebAPI.Mapper;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IService _service;
        public VehicleController(IService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<Vehicle>>> Get(string agency, string route, double latitude, double longitude)
        {
            var vehiclesDomain = await _service.GetVehicleList(agency, route, latitude, longitude);
            var vehicles = vehiclesDomain.Select(Mapping.ConvertFromDomain).ToList();
            return Ok(vehicles);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Vehicle>> GetById(string vehicleId, string agency, string route, double? latitude = null, double? longitude = null)
        {
            var vehicleDomain = await _service.GetVehicleById(vehicleId, agency, route, latitude, longitude);
            var vehicle = Mapping.ConvertFromDomain(vehicleDomain);
            return Ok(vehicle);
        }

        [HttpGet]
        [Route("GetTextById")]
        public async Task<ActionResult<string>> GetTextById(string vehicleId, string agency, string route, double? latitude = null, double? longitude = null)
        {
            var vehicleDomain = await _service.GetVehicleById(vehicleId, agency, route, latitude, longitude);
            var vehicle = Mapping.ConvertFromDomain(vehicleDomain);
            return Ok(vehicle.ToString());
        }
    }
}
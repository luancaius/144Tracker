using GrabData.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrabData.Services
{
    public class GrabService : IGrabService
    {
        private IRawService _rawService;
        private IRepository<Repository.Models.Vehicle> _repository;
        private Dictionary<string, List<Vehicle>> _routeVehicles;
       
        public GrabService(IRawService rawService, IRepository<Repository.Models.Vehicle> repository)
        {
            _rawService = rawService;
            _repository = repository;
            _routeVehicles = new Dictionary<string, List<Vehicle>>();
        }

        public async Task GetVehicles(string agency, string route)
        {
            var vehicles = await _rawService.GetVehicles(agency, route);
            var firstNotSecond = _routeVehicles[route].Except(vehicles).ToList();
            var secondNotFirst = vehicles.Except(_routeVehicles[route]).ToList();
            if(!firstNotSecond.Any() && !secondNotFirst.Any())
            {
                Console.WriteLine("----------Changing list!!!");
            }
            _routeVehicles[route] = vehicles;
        }

        public async Task GetVehicle(string agency)
        {
            var routes = _routeVehicles.Keys.ToList();
            foreach(var route in routes)
            {
                var listVehicles = _routeVehicles[route];
                foreach(var vehicle in listVehicles)
                {
                    var vehicleInfo = await _rawService.GetVehicle(agency, route, vehicle.VehicleId);
                    await SaveAsync(vehicleInfo);
                }
            }            
        }

        private async Task SaveAsync(Vehicle vehicle)
        {
            var vehicleDTO = Vehicle.ConvertFrom(vehicle);
            await _repository.Save(vehicleDTO, CancellationToken.None);
        }
    }
}

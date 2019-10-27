using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Repository.Interfaces;
using GrabData.Refit;
using GrabData.Models;

namespace GrabData.Services
{
    public class RawService : IRawService
    {
        private readonly INextBusApi _nextBusApi;
        private IRepository<Repository.Models.Vehicle> _repository;
        private HashSet<string> _vehicleHashSet;
        private string _agency;
        private string _route;
        private int _countTimer = 0;
        private Timer _timer;
        public RawService(IRepository<Repository.Models.Vehicle> repository)
        {
            _nextBusApi = RestService.For<INextBusApi>("http://webservices.nextbus.com/service/publicJSONFeed");
            _repository = repository;
            _vehicleHashSet = new HashSet<string>();
        }

        public async Task Execute(string agency, string route)
        {
            _agency = agency;
            _route = route;

            Console.WriteLine($"Start Execute - {DateTime.Now}");
            await UpdateVehicleList(agency, route);

            if (_vehicleHashSet.Any())
            {
                _timer = new Timer(TimerCallBack, null, 0, 15 * 1000);
            }
        }

        private async void TimerCallBack(object state)
        {
            _countTimer+=15;
            await UpdateVehicle(_agency, _route);
            if (_countTimer > (5 * 60 - 10))
                await _timer.DisposeAsync();
        }

        private async Task UpdateVehicle(string agency, string route)
        {
            Console.WriteLine($"Start UpdateVehicle");

            var taskList = new List<Task<Vehicle>>();
            foreach (var vehicleId in _vehicleHashSet)
            { 
                taskList.Add(GetVehicle(agency, route, vehicleId));
            }
            var listVehicle = await Task.WhenAll(taskList);

            Parallel.ForEach(listVehicle, async (vehicle) => await SaveAsync(vehicle));
            Console.WriteLine($"Start UpdateVehicle");
        }

        private async Task UpdateVehicleList(string agency, string route)
        {
            Console.WriteLine($"Start UpdateVehicleList");
            var list = await GetVehicles(agency, route);
            if (list == null)
                _vehicleHashSet.Clear();
            foreach (var item in list)
            {
                _vehicleHashSet.Add(item);
            }
            Console.WriteLine($"End UpdateVehicleList - total:{_vehicleHashSet.Count}");
        }

        private async Task<List<string>> GetVehicles(string agency, string route)
        {
            try
            {
                Console.WriteLine($"Start GetVehicles");
                var apiResponse = await _nextBusApi.GetRouteVehicles("vehicleLocations", agency, route, "0");
                var vehicles = apiResponse.VehicleList.ToList();
                var vehicleIds = vehicles.Select(a => a.VehicleId).ToList();
                Console.WriteLine($"End GetVehicles: {vehicleIds.Count} vehicles");
                return vehicleIds;
            }
            catch (Exception)
            {
            }
            return null;
        }

        private async Task<Vehicle> GetVehicle(string agency, string route, string vehicleId)
        {
            try
            {
                var vehicleResponse = await _nextBusApi.GetRouteVehicle("vehicleLocation", agency, route, "0", vehicleId);
                return vehicleResponse.Vehicle;
            }
            catch (ValidationApiException)
            {
            }
            catch (ApiException)
            {
            }
            return null;
        }

        private async Task SaveAsync(Vehicle vehicle)
        {
            var vehicleDTO = Vehicle.ConvertFrom(vehicle);
            await _repository.Save(vehicleDTO, CancellationToken.None);
        }
    }
}

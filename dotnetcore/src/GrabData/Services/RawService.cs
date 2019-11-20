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
        private int _interval = 15;
        private int _lastTotal;
        private Timer _timer;
        public RawService(IRepository<Repository.Models.Vehicle> repository)
        {
            _nextBusApi = RestService.For<INextBusApi>("http://webservices.nextbus.com/service/publicJSONFeed");
            _repository = repository;
            _vehicleHashSet = new HashSet<string>();
        }

        public async Task<List<Vehicle>> GetVehicles(string agency, string route)
        {
            try
            {
                Console.WriteLine($"Start GetVehicles");
                var apiResponse = await _nextBusApi.GetRouteVehicles("vehicleLocations", agency, route, "0");
                var vehicles = apiResponse.VehicleList;
                Console.WriteLine($"End GetVehicles: {vehicles.Count} vehicles");
                return vehicles;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception GetVehicles: {e.Message}");
            }
            return null;
        }

        public async Task<Vehicle> GetVehicle(string agency, string route, string vehicleId)
        {
            try
            {
                var vehicleResponse = await _nextBusApi.GetRouteVehicle("vehicleLocation", agency, route, "0", vehicleId);
                return vehicleResponse.Vehicle;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception GetVehicles: {e.Message}");
            }
            return null;
        }

        //public async Task Execute(string agency, string route)
        //{
        //    _agency = agency;
        //    _route = route;
        //    Console.WriteLine($"Start Execute - {DateTime.Now}");
        //    await UpdateVehicleList(agency, route);

        //    if (_vehicleHashSet.Any())
        //    {

        //        if (_timer != null)
        //            await _timer.DisposeAsync();
        //        _timer = new Timer(TimerCallBack, null, 0, _interval * 1000);
        //    }
        //    else
        //    {
        //        Console.WriteLine($"{DateTime.Now} - No buses for route {_route}");
        //    }
        //}

        //private async void TimerCallBack(object state)
        //{
        //    await UpdateVehicle(_agency, _route);
        //}

        //private async Task UpdateVehicle(string agency, string route)
        //{
        //    Console.WriteLine($"Start UpdateVehicle");

        //    var taskList = new List<Task<Vehicle>>();
        //    foreach (var vehicleId in _vehicleHashSet)
        //    { 
        //        taskList.Add(GetVehicle(agency, route, vehicleId));
        //    }
        //    var listVehicle = await Task.WhenAll(taskList);

        //    Parallel.ForEach(listVehicle, async (vehicle) => await SaveAsync(vehicle));
        //    Console.WriteLine($"Start UpdateVehicle");
        //}

        //private async Task UpdateVehicleList(string agency, string route)
        //{
        //    Console.WriteLine($"Start UpdateVehicleList");
        //    var list = await GetVehicles(agency, route);
        //    if (list == null)
        //        _vehicleHashSet.Clear();
        //    else
        //    {
        //        if (_lastTotal != _vehicleHashSet.Count)
        //        {
        //            Console.WriteLine($"-------------- From {_lastTotal} to {_vehicleHashSet.Count} -------------");
        //            _lastTotal = _vehicleHashSet.Count;
        //        }
        //    }
        //    foreach (var item in list)
        //    {
        //        _vehicleHashSet.Add(item);
        //    }
        //    Console.WriteLine($"End UpdateVehicleList - total:{_vehicleHashSet.Count}");
        //}        

        //private async Task SaveAsync(Vehicle vehicle)
        //{
        //    var vehicleDTO = Vehicle.ConvertFrom(vehicle);
        //    await _repository.Save(vehicleDTO, CancellationToken.None);
        //}
    }
}

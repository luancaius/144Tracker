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
        private List<string> _vehiclesIds;

        public GrabService(IRawService rawService, IRepository<Repository.Models.Vehicle> repository)
        {
            Console.WriteLine("Inside GrabService");
            _rawService = rawService;
            _repository = repository;
            _vehiclesIds = new List<string>();
        }

        public async Task GetVehicles(string agency, string route)
        {
            Console.WriteLine($"GetVehicles - Total list {_vehiclesIds.Count}");
            var vehicles = await _rawService.GetVehicles(agency, route);
            if (vehicles != null)
            {
                var vehiclesIds = vehicles.Select(a => a.VehicleId).ToList();
                ExtractFinalList(vehiclesIds, _vehiclesIds);
                _vehiclesIds = vehiclesIds;
            }
        }

        public async Task GetVehicle(string agency, string route)
        {
            //Console.WriteLine($"GetVehicle - Total list {_vehiclesIds.Count}");
            var listTask = new List<Task>();
            foreach(var vehicleId in _vehiclesIds)
            {
                listTask.Add(SaveAsync(agency, route, vehicleId));
            }
            Task.WaitAll(listTask.ToArray());            
        }

        private async Task SaveAsync(string agency, string route, string vehicleId)
        {
            var vehicleInfo = await _rawService.GetVehicle(agency, route, vehicleId);
            if (vehicleInfo != null)
            {
                Console.WriteLine($"Saving info for {vehicleInfo.VehicleId}");
                var vehicleDTO = Vehicle.ConvertFrom(vehicleInfo);
                await _repository.Save(vehicleDTO, CancellationToken.None);
            }
        }

        private void ExtractFinalList(List<string> newList, List<string> oldList)
        {
            var listAdd = newList.Except(oldList).ToList();
            var listDelete = oldList.Except(newList).ToList();
            if (!listAdd.Any() && !listDelete.Any())
                Console.WriteLine("#####NO Change###");
            PrintList("##### +++++ list add", listAdd);
            PrintList("##### ----- list delete", listDelete);            
        }

        private void PrintList(string title, List<string> list)
        {
            if (!list.Any())
                return;
            Console.Write(title + "\t");
            foreach(var item in list)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }
    }
}

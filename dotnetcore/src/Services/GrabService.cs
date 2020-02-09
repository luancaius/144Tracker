using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Provider.NextBus;
using Repository.Interfaces;

namespace Service
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
                var vehiclesIds = vehicles.Select(a => a.Id).ToList();
                ExtractFinalList(vehiclesIds, _vehiclesIds);
                _vehiclesIds = vehiclesIds;
            }
        }
        private async Task SaveAsync(string agency, string route, string vehicleId)
        {
            var vehicleInfo = await _rawService.GetVehicle(agency, route, vehicleId);
            if (vehicleInfo != null)
            {
                //var vehicleDTO = Repository.Models.Vehicle.ConvertFrom(vehicleInfo);
                //await _repository.Save(vehicleDTO, CancellationToken.None);
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

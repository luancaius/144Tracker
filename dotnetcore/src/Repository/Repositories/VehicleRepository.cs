using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Nest;
using Repository.Models;

namespace Repository.Repositories
{
    public class VehicleRepository : Interfaces.IRepository<Vehicle>
    {
        private IElasticClient _elasticClient;
        public VehicleRepository()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("vehicles");
            _elasticClient = new ElasticClient(settings);
        }
        
        public IEnumerable<Vehicle> List(string userid)
        {
            throw new NotImplementedException();
        }

        public Vehicle Get(string id)
        {
            throw new NotImplementedException();
        }
        public async Task Save(Vehicle vehicle, CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine($"Saving {vehicle.ToString()}");
                var response = await _elasticClient.IndexDocumentAsync(vehicle, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> Search(string query)
        {
            throw new NotImplementedException();
        }
    }
}
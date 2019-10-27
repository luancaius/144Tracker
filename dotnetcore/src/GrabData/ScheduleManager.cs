using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrabData
{
    public class ScheduleManager : IHostedService, IDisposable
    {
        private Timer _timer;
        private Timer _timer2;

        private int _second = 1000;
        private int _minute = 1000*60;
        private RawService _rawService;

        private string _route = "100";
        private string _agency = "ttc";
        private HashSet<string> _listVehicleId;
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _listVehicleId = new HashSet<string>();
            _rawService = new RawService();
            _timer = new Timer(GetRouteInfo, null, 0, 5*_minute);
            _timer2 = new Timer(GetBusInfo, null, 0, 1000*_second);
        }

        async void GetRouteInfo(object state)
        {
            Console.WriteLine($"Calling GetBusList - {DateTime.Now.ToLongTimeString()}");
            var listVehicleIds = await _rawService.IndexRouteVehicles(_agency, _route);
            foreach (var vehicleId in listVehicleIds)
            {
                _listVehicleId.Add(vehicleId);
            }
        }
        async void GetBusInfo(object state)
        {
            Console.WriteLine($"Calling GetBusList - {DateTime.Now.ToLongTimeString()}");
            await _rawService.IndexRouteVehicle(_agency, _route, _listVehicleId);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            _timer2?.Change(Timeout.Infinite, 0);

            Console.WriteLine("GrabData - Stop");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer.Dispose();
            _timer2.Dispose();
        }
    }
}

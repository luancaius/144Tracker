using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;

namespace GrabData
{
    public class ScheduleManager : IHostedService, IDisposable
    {
        private Timer _timer;
        private Timer _timer2;

        private const int _second = 1000;
        private const int _minute = _second * 60;
        private IGrabService _grabService;

        private string _agency;
        private string _route;
        public ScheduleManager(IGrabService grabService)
        {
            _agency = "ttc";
            _route = "25";
            _grabService = grabService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("GrabData - Start");
            _timer = new Timer(GetVehicleList, null, 0, 200 * _second);
            _timer2 = new Timer(GetVehicle, null, 0, 10 * _second);
            await Task.CompletedTask;
        }

        void GetVehicleList(object state)
        {
            Console.WriteLine($"----Calling Timer GetVehicleList - {DateTime.Now.ToLongTimeString()}");

            _grabService.GetVehicles(_agency, _route);
        }

        void GetVehicle(object state)
        {
            //Console.WriteLine($"----Calling Timer GetVehicle - {DateTime.Now.ToLongTimeString()}");

            //_grabService.GetVehicle(_agency, _route);
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

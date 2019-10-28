using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using GrabData.Services;

namespace GrabData
{
    public class HostManager : IHostedService, IDisposable
    {
        private Timer _timer;

        private int _minute = 1000*60;
        private IRawService _rawService;

        private string _agency = "ttc";

        public HostManager(IRawService rawService)
        {
            _rawService = rawService;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(GetRouteInfo, null, 0, 5*_minute);
            await Task.CompletedTask;
        }

        void GetRouteInfo(object state)
        {
            Console.WriteLine($"Calling Execute - {DateTime.Now.ToLongTimeString()}");
            _rawService.Execute(_agency, "144");
            _rawService.Execute(_agency, "100");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            Console.WriteLine("GrabData - Stop");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}

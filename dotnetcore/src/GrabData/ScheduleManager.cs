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
    public class ScheduleManager : IHostedService
    {
        private Timer _timer;
        private Timer _timer2;

        private int _second = 1000;
        private int _minute = 1000*60;
        private RawService _rawService;

        private string _route = "100";
        private string _agency = "ttc";

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("GrabData - Start");

            _rawService = new RawService();
            _timer = new Timer(GetBusId, null, 0, 5*_minute);

  
        }

        async void GetBusId(object state)
        {
            Console.WriteLine($"Calling GetBusList - {DateTime.Now.ToLongTimeString()}");
            await _rawService.IndexRouteBusList(_agency, _route);
        }



        public Task StopAsync(CancellationToken cancellationToken)
        {
            //_timer?.Change(Timeout.Infinite, 0);
            //_timer2?.Change(Timeout.Infinite, 0);

            Console.WriteLine("GrabData - Stop");
            return Task.CompletedTask;
        }
    }
}

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

        private string _route = "144";
        private string _agency = "ttc";

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("GrabData - Start");

            _rawService = new RawService();
            //_timer = new Timer(GetBusId, null, 0, 5*_second);
            _timer2 = new Timer(GetBusList, null, 0, 500 * _second);

            return Task.CompletedTask;
        }

        void GetBusId(object state)
        {
            Console.WriteLine($"Calling GetBusId - {DateTime.Now.ToLongTimeString()}");
        }

        void GetBusList(object state)
        {
            Console.WriteLine($"Calling GetBusList - {DateTime.Now.ToLongTimeString()}");
            var list = Task.Run(() => _rawService.IndexRouteBusList(_agency, _route)).Result;
            list.Count();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            _timer2?.Change(Timeout.Infinite, 0);

            Console.WriteLine("GrabData - Stop");
            return Task.CompletedTask;
        }
    }
}

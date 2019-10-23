using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrabData
{
    public class RawService : IHostedService
    {
        private Timer _timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(HelloWorld, null, 0, 5000);
            Console.WriteLine("GrabData - Start");

            return Task.CompletedTask;
        }

        void HelloWorld(object state)
        {
            Console.WriteLine($"Time - {DateTime.Now.ToLongTimeString()}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //New Timer does not have a stop. 
            _timer?.Change(Timeout.Infinite, 0);
            Console.WriteLine("GrabData - Stop");
            return Task.CompletedTask;
        }
    }
}

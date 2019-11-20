﻿using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using GrabData.Services;
using System.Collections.Generic;

namespace GrabData
{
    public class ScheduleManager : IHostedService, IDisposable
    {
        private Timer _timer;
        private Timer _timer2;

        private const int _minute = 1000*60;        
        private IGrabService _grabService;

        private Dictionary<string, List<String>> _agencies;

        public ScheduleManager(IGrabService grabService)
        {
            _agencies = new Dictionary<string, List<string>>{ { "ttc", new List<string> { "100" } } };
            _grabService = grabService;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("GrabData - Start");
            _timer = new Timer(GetVehicleList, null, 0, 5*_minute);
            _timer2 = new Timer(GetVehicleList, null, 0, 5 * _minute);
            await Task.CompletedTask;
        }

        void GetVehicleList(object state)
        {
            Console.WriteLine($"Calling Timer GetVehicleList - {DateTime.Now.ToLongTimeString()}");
            foreach(var agency in _agencies.Keys)
            {
                foreach(var route in _agencies[agency])
                {
                    _grabService.GetVehicles(agency, route);
                }                
            }            
        }

        void GetVehicle(object state)
        {
            Console.WriteLine($"Calling Timer GetVehicle - {DateTime.Now.ToLongTimeString()}");
            foreach (var agency in _agencies.Keys)
            {
                foreach (var route in _agencies[agency])
                {
                    _grabService.GetVehicle();
                }
            }
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

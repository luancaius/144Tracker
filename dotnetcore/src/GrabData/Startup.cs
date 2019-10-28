using Elasticsearch.Net;
using GrabData.Services;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Text;

namespace GrabData
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRawService, RawService>();
            services.AddScoped<Repository.Interfaces.IRepository<Repository.Models.Vehicle>, VehicleRepository>();

            services.AddHostedService<HostManager>();
        }        
    }
}
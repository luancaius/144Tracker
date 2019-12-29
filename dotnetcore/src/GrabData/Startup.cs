using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Provider.NextBus;
using Repository.Interfaces;
using Repository.Repositories;
using Service;

namespace GrabData
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGrabService, GrabService>();
            services.AddScoped<IRawService, RawService>();
            services.AddScoped<IRepository<Repository.Models.Vehicle>, VehicleRepository>();            

            services.AddHostedService<ScheduleManager>();
        }
    }
}
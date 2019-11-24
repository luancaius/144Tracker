using GrabData.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Interfaces;
using Repository.Repositories;

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
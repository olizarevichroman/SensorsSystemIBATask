using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SensorsSystem.DataLayer.Contracts;
using SensorsSystem.DataLayer.Contracts.FileSystem;
using SensorsSystem.DataLayer.Implementations;
using SensorsSystem.DataLayer.Implementations.FileSystem;
using SensorsSystem.DataLayer.Models;
using SensorsSystem.Filters;
using SensorsSystem.Options;

namespace SensorsSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IRepository<SpeedSensorData>, FileSystemRepository<SpeedSensorData>>();
            services.AddScoped<IFileSystemManager<SpeedSensorData>, FileSystemManager<SpeedSensorData>>();
            services.AddSingleton<IFileManager<SpeedSensorData>, JsonFileManager<SpeedSensorData>>();
            services.AddScoped<RestrictDataSelectionAttribute>();
            services.Configure<DataRestrictionOptions>(Configuration.GetSection(nameof(DataRestrictionOptions)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

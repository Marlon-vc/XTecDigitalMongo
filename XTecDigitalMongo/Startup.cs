using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using XTecDigitalMongo.Models;
using XTecDigitalMongo.Services;

namespace XTecDigitalMongo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<XTecDigitalDbSettings>(
                Configuration.GetSection(nameof(XTecDigitalDbSettings)));
            
            services.AddSingleton<IXTecDigitalDbSettings>(sp => 
                sp.GetRequiredService<IOptions<XTecDigitalDbSettings>>().Value);

            services.AddSingleton<ProfesorService>();
            services.AddSingleton<EstudianteService>();
            services.AddSingleton<AdminService>();

            services.AddControllers();
        }

        //public static void AddDbSettings(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var settings = configuration.GetSection(nameof(XTecDigitalDbSettings));
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

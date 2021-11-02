using FluentValidation.AspNetCore;
using JourneyHero.Api.EntryPoint.Aplicacion;
using JourneyHero.Api.EntryPoint.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyHero.Api.EntryPoint
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
            //Adding fluent validation
            services.AddControllers().AddFluentValidation(cnfg => cnfg.RegisterValidatorsFromAssemblyContaining<NuevoTienda>());

            services.AddControllers();


            //Setting Connection to MySql
            string dbConnection = Configuration.GetConnectionString("ConexionDB");

            services.AddDbContext<ContextEP>(options =>
            {
                options.UseMySql(dbConnection, ServerVersion.AutoDetect(dbConnection));
            });

            //Adding MediaTR as Service
            services.AddMediatR(typeof(NuevoTienda.Handler).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

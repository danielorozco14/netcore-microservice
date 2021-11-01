using FluentValidation.AspNetCore;
using JourneyHero.Api.StoreC.Aplicacion;
using JourneyHero.Api.StoreC.Persistence;
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

namespace JourneyHero.Api.StoreC
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
            services.AddControllers().AddFluentValidation(cnfg => cnfg.RegisterValidatorsFromAssemblyContaining<NuevoMarca>());
            services.AddControllers().AddFluentValidation(cnfg => cnfg.RegisterValidatorsFromAssemblyContaining<NuevoCarro>());
            services.AddControllers().AddFluentValidation(cnfg => cnfg.RegisterValidatorsFromAssemblyContaining<NuevoRepuesto>());

            services.AddControllers();

            services.AddControllers();
            //Setting Connection to MySql
            string dbConnection = Configuration.GetConnectionString("ConexionDB");

            services.AddDbContext<ContextStoreC>(options =>
            {
                options.UseMySql(dbConnection, ServerVersion.AutoDetect(dbConnection));
            });

            //Adding MediaTR as Service
            services.AddMediatR(typeof(NuevoMarca.Handler).Assembly);
            services.AddMediatR(typeof(NuevoCarro.Handler).Assembly);
            services.AddMediatR(typeof(NuevoRepuesto.Handler).Assembly);
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

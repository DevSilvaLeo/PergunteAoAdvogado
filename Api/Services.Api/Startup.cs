using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Dados.Contracts;
using DataLayer.Dados.Repositories;
using Microsoft.OpenApi.Models;

namespace Services.Api
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
            services.AddControllers();

            var connection = Configuration.GetConnectionString("DbConn");

            services.AddTransient<IClienteRepository, ClienteRepository>(map => new ClienteRepository(connection));
            services.AddTransient<IDemandaRepository, DemandaRepository>(map => new DemandaRepository(connection));
            services.AddTransient<IAdvogadoRepository, AdvogadoRepository>(map => new AdvogadoRepository(connection));
            services.AddTransient<IPerfilRepository, PerfilRepository>(map => new PerfilRepository(connection));
            
            services.AddSwaggerGen(
                swg =>
                {
                    swg.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Consulta Adv - Suzane Adv",
                        Version = "v1",
                        Description = "API de serviços do projeto Consulta ADV"
                    });
                });

            //services.AddCors();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

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

            app.UseCors(x => x
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .SetIsOriginAllowed(origin => true));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                swgUi =>
                {
                    swgUi.SwaggerEndpoint("/swagger/v1/swagger.json", "AdvConsulta");
                }  
            );

            
           
            
        }
    }
}

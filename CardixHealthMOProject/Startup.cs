using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardixHealthMOProject.DataAccess.Dapper;
using CardixHealthMOProject.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CardixHealthMOProject
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
            services.AddScoped<ICardixPatientService, CardixPatientService>();
            services.AddScoped<ICardixPatientRepository, CardixPatientRepository>();
            services.AddSwaggerGen( c => {
                c.SwaggerDoc("swagger/v1/swagger.json", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Cardix Health Managment Org API", Version = "v1" });
                
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("v1", "Cardix HMO API Endpoints");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}

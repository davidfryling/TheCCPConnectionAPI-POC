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
using TheCCPConnectionAPI_POC.Common;
using TheCCPConnectionAPI_POC.IServices;
using TheCCPConnectionAPI_POC.Services;

namespace TheCCPConnectionAPI_POC
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

            //THIS ALLOWS API TO RUN ON LOCAL HOST WITHOUT ERRORS -- IS THIS A SECURITY ISSUE IN PRODUCTION??
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "AllowOrigin",
                    builder => {
                        builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
            });

            //FULL VERSION NOTE -- Add code below to tell app to use connections string and service classes 
            Global.ConnectionString = Configuration.GetConnectionString("TheCCPconnectionAPI-POC");

            //FULL VERSION NOTE -- Add code below to map interface to the class that implements it (replaces entire packages such as Autofac)
            services.AddScoped<IRequestService, RequestService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //THIS ALLOWS API TO RUN ON LOCAL HOST WITHOUT ERRORS -- IS THIS A SECURITY ISSUE IN PRODUCTION??
            app.UseCors("AllowOrigin");

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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Twith.API.StartupExtensions;
using Twith.API.Validation;
using Twith.IoC;

namespace Twith.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services
                .AddMvc(options => options.ModelMetadataDetailsProviders.Add(new ApiValidationMetadataProvider()))
                .AddNewtonsoftJson(mvcNewtonsoftJsonOptions =>
                    mvcNewtonsoftJsonOptions.UseCamelCasing(true));
            
            services.AddMediatR(AppDomain.CurrentDomain.Load("Twith.Application"));

            // Database
            services.AddCustomizedDatabase(Configuration, _env);

            // Swagger UI
            services.AddCustomizedSwagger();

            // Auth
            services.AddCustomizedAuth(Configuration);

            IoCConfiguration.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Swagger UI
                app.UseCustomizedSwagger();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Auth
            app.UseCustomizedAuth();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
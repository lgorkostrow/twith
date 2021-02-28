using System;
using System.IO;
using System.Reflection;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Twith.API.Authorizations.Handlers;
using Twith.API.StartupExtensions;
using Twith.Application.Service;
using Twith.Domain.Twith.Repositories;
using Twith.Domain.User.Repositories;
using Twith.Infrastructure.Data;
using Twith.Infrastructure.Data.Repositories;
using Twith.Infrastructure.Identity;
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
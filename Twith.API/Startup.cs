using System;
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
using Twith.Application.Service;
using Twith.Domain.Twith.Repositories;
using Twith.Domain.User.Repositories;
using Twith.Infrastructure.Data;
using Twith.Infrastructure.Data.Repositories;
using Twith.Infrastructure.Identity;

namespace Twith.API
{
    public class Startup
    {
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMediatR(AppDomain.CurrentDomain.Load("Twith.Application"));

            services.AddDbContext<ApplicationDbContext>(
                options => options
                    .UseNpgsql("name=ConnectionStrings:DefaultConnection")
                    .UseSnakeCaseNamingConvention()
                    .EnableSensitiveDataLogging(Configuration.GetValue<bool>("Logging:EnableSqlParameterLogging")));

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Twith.API", Version = "v1"}); });

            // Domain
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITwithRepository, TwithRepository>();
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
            
            ConfigureIdentity(services);
            ConfigureAuthorization(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Twith.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureIdentity(IServiceCollection services)
        {
            services.AddScoped<ITokenClaimsService>(x =>
                new IdentityTokenClaimService("asdasdasdasdasdasd",
                    x.GetRequiredService<UserManager<ApplicationUser>>()));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseNpgsql("name=ConnectionStrings:IdentityConnection")
                    .UseSnakeCaseNamingConvention()
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            var key = Encoding.ASCII.GetBytes("asdasdasdasdasdasd");
            services
                .AddAuthentication(config =>
                {
                    config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(config =>
                {
                    config.RequireHttpsMetadata = false;
                    config.SaveToken = true;
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        public void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddScoped<IAuthorizationHandler, SameTwithAuthorAuthorizationHandler>();
        }
    }
}
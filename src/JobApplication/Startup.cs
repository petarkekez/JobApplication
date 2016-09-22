using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using JobApplication.Database.IReporistory;
using JobApplication.Database.Reporistory;

namespace JobApplication
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddDbContext<Database.JobContext>( );

            services.AddScoped<IJuniorTaskReporitory, JuniorTaskReporitory>();

            services.AddTransient<Database.JobContextSeedData>();

            services.AddMvc()
                .AddJsonOptions(config =>
                {
                    config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, Database.JobContextSeedData seeder)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Test"))
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug(LogLevel.Debug);
            }
            else
            {
                loggerFactory.AddDebug(LogLevel.Error);
            }
            app.UseMvcWithDefaultRoute();

            seeder.EnsureSeedData().Wait();
            
        }
    }
}

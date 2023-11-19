using Voyages.Domain;
using Voyages.SqlDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Voyages.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHttpContextAccessor();

            var appSettings = this.Configuration.GetSection("AppSettings");
            var configuration = new VoyagesConfiguration(
                    connectionString: this.Configuration.GetConnectionString("VoyagesConnectionString"),
                    voyageRepositoryTypeName: appSettings.GetValue<string>("VoyageRepositoryType"));
            var contexto = new VoyagesContext(configuration.ConnectionString);

            var controllerActivator = new VoyagesControllerActivator(
                configuration: new VoyagesConfiguration(
                    connectionString: this.Configuration.GetConnectionString("VoyagesConnectionString"),
                    voyageRepositoryTypeName: appSettings.GetValue<string>("VoyageRepositoryType")));

            services.AddSingleton<IControllerActivator>(controllerActivator);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ConfigureLogging(app, loggerFactory);

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }

        private static void ConfigureLogging(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger("Logging");

            app.Use(async (context, next) =>
            {
                var logging = new Logging(logger);

                await logging.Invoke(context, next);
            });
        }
    }
}
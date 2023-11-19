using GraphiQl;
using Voyages.GraphQL.Api.GraphqlCore;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GraphQL;

namespace Voyages.GraphQL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //To execute in localhost
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                        .AllowCredentials();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            var appSettings = this.Configuration.GetSection("AppSettings");
            var voyagesApiRestBaseUrl = appSettings.GetValue<string>("VoyagesApiRestEndpoint");

            //services.AddSingleton(new VoyagesQuery(voyagesApiRestBaseUrl));
            services.AddSingleton(new VoyageByClientNameQuery(voyagesApiRestBaseUrl));
            services.AddSingleton(new ClientType(voyagesApiRestBaseUrl));
            services.AddSingleton(new FileType(voyagesApiRestBaseUrl));
            services.AddSingleton<ProductType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new VoyagesSchema(new FuncDependencyResolver(type => sp.GetService(type))));
   
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //To execute in localhost
            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            ConfigureLogging(app, loggerFactory);

            app.UseGraphiQl("/graphql");
            //app.UseGraphQL<VoyageSchema>();
            //app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
            
            //app.UseHttpsRedirection();
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

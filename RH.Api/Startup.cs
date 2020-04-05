using Core.Web.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RH.Infra.Context;
using RH.Infra.Ioc;
using System;

namespace RH.Api
{
    public class Startup
    { 
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //MongoDbContext.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            //MongoDbContext.DatabaseName = Configuration.GetSection("MongoConnection:Database").Value;
            //MongoDbContext.IsSSL = Convert.ToBoolean(this.Configuration.GetSection("MongoConnection:IsSSL").Value);


            services.AddDbContext<RHContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<EventStoreSqlContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddMediatR(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerExtension("RH","1.0");

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // .NET Native DI Abstraction
            //services.AddDependencyInjectionSetup();
            NativeInjectorBootStrapper.RegisterServices(services);

            services.AddRabbitMQEventBus("amqp://localhost", eventBusOptionAction: eventBusOption =>
            {
                eventBusOption.ClientProvidedAssembly<Startup>();
                eventBusOption.EnableRetryOnFailure(true, 5000, TimeSpan.FromSeconds(30));
                eventBusOption.RetryOnFailure(TimeSpan.FromSeconds(1));
            },"guest");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.RabbitMQEventBusAutoSubscribe();

            app.UseCustomSwagger("RH");

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

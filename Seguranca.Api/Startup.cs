using Core.Web.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Seguranca
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
            services.AddDatabaseSetup(Configuration);
            services.AddMediatR(typeof(Startup));
            services.AddControllers();
            services.AddSwaggerExtension("Segurança", "1.0");

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // .NET Native DI Abstraction
            services.AddDependencyInjectionSetup();

            services.AddRabbitMQEventBus("amqp://localhost", eventBusOptionAction: eventBusOption =>
            {
                eventBusOption.ClientProvidedAssembly<Seguranca.Domain.Usuario.Subscribes.NovoUsuarioEventHandler>();
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

            app.UseCustomSwagger("Segurança");

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

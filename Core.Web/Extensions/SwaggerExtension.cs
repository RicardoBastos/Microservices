using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Core.Web.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection services, string title,string version)
        {

           

            services.AddSwaggerGen(c =>
            {
             
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = title, 
                    Version = version,
                    Description = "Swagger API",
                    TermsOfService = new Uri("https://meusite/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Ricardo Bastos",
                        Email = "ricardo3bastos@gmail.com",
                        Url = new Uri("https://meusite"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licença",
                        Url = new Uri("https://meusite/license"),
                    }
                });
            });
        }

        public static void UseCustomSwagger(this IApplicationBuilder app, string definition)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", definition);
            });
        }
    }
}

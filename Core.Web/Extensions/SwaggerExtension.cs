using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

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




                     c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                     {
                         Description =
         "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' token",
                         Name = "Authorization",
                         In = ParameterLocation.Header,
                         Type = SecuritySchemeType.ApiKey,
                         Scheme = "Bearer"
                     });

                     c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
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

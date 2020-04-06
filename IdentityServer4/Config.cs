using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("SampleService","All services for testing")
            };
        }

        public static IEnumerable<Client> GetClients([FromServices]IConfiguration configuration)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ClientId",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowAccessTokensViaBrowser = true,
                    ClientSecrets =
                    {
                        new Secret("ClientSecret".Sha256())
                    },
                    AllowedScopes = { "SampleService" },
                    AccessTokenLifetime =3600,
                    RedirectUris = {"https://localhost:6001/o2c.html"},
                }
                //new Client {
                //    ClientId = "demo_api_swagger",
                //    ClientName = "Swagger UI for demo_api",
                //    AllowedGrantTypes = GrantTypes.Implicit,
                //    AllowAccessTokensViaBrowser = true,
                //    RedirectUris = {"http://localhost:5001/oauth2-redirect.html"},
                //    AllowedScopes = {"demo_api"}
            };
        
        }
    }
}

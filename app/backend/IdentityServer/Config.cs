using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("email", new List<string> { "email" }),
            new IdentityResource("role", new List<string> { "role" }),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope("CatalogAPI"),

                new ApiScope("React"),
                
            };

    public static IEnumerable<Client> Clients =>
        new Client[]
            {
                new Client
                {
                    ClientId = "weather_api_swagger",
                    ClientName = "Swagger UI for Weather API",
                    ClientSecrets = { new Secret("weather_api_secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    AlwaysIncludeUserClaimsInIdToken = true,

                    RedirectUris = { "http://localhost:5000/swagger/oauth2-redirect.html" },

                    AllowedCorsOrigins = { "http://localhost:5000" },
                    AllowedScopes = new List<string>
                    {
                        "CatalogAPI"
                    },
                },

                new Client
                {
                    ClientId = "react_client",
                    ClientName = "React Client",
                    ClientSecrets = { new Secret("react_secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code.Union(GrantTypes.ResourceOwnerPasswordAndClientCredentials).ToList(),

                    RequirePkce = true,
                    RequireClientSecret = false,

                    AlwaysIncludeUserClaimsInIdToken = true,

                    RedirectUris = { "https://localhost:3000/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:3000/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:3000/signout-callback-oidc" },                   

                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "profile",
                        "React",
                        "email",
                        "CatalogAPI",
                        "role",
                    },

                    AllowOfflineAccess = true
                },


            };
}
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using WeatherForecast.API.Models;
using Catalog.API.Abstractions.Services;

namespace Catalog.API.Application.Services;

public class LoginService : ILoginService
{
    public async Task<TokenResponse> CheckCredentialsAsync(HttpClient client, Login login)
    {
        var discoveryDocument = await client.GetDiscoveryDocumentAsync("https://localhost:5001");

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = discoveryDocument.TokenEndpoint,
            ClientId = "react_client",
            ClientSecret = "react_secret",
            Scope = "openid profile React email CatalogAPI role",
            UserName = login.UserLogin,
            Password = login.UserPassword
        });

        return tokenResponse;
    }
}
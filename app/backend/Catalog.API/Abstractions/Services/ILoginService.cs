using IdentityModel.Client;
using WeatherForecast.API.Models;

namespace Catalog.API.Abstractions.Services;

public interface ILoginService
{
    Task<TokenResponse> CheckCredentialsAsync(HttpClient client, Login login);
}
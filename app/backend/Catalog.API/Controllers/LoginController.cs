using Catalog.API.Abstractions.Services;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.API.Models;

namespace WeatherForecast.API.Controllers;

[ApiController]
[Route("login")]
//[Authorize(Policy = "WeatherApiScope")]
[AllowAnonymous]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(Login login)
    {
        try
        {
            var client = new HttpClient();
            var tokenResponse = await _loginService.CheckCredentialsAsync(client, login);
            if (!tokenResponse.IsError)
            {
                var userInfoResponse = await client.GetUserInfoAsync(new UserInfoRequest
                {
                    Address = (await client.GetDiscoveryDocumentAsync("https://localhost:5001")).UserInfoEndpoint,
                    Token = tokenResponse.AccessToken
                });

                if (!userInfoResponse.IsError)
                {
                    var claims = userInfoResponse.Claims;
                    var userId = claims.FirstOrDefault(c => c.Type == "sub")?.Value;
                    var userName = claims.FirstOrDefault(c => c.Type == "name")?.Value;
                    var email = claims.FirstOrDefault(c => c.Type == "email")?.Value;
                    var role = claims.FirstOrDefault(c => c.Type == "role")?.Value;


                    return Ok(new { tokenResponse.AccessToken, userId, userName, email, role });
                }
                else
                {
                    return BadRequest(userInfoResponse.Error);
                }
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
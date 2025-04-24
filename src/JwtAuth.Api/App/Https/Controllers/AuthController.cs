using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuth.Api.App.Dtos;
using JwtAuth.Api.App.Services.Auth;
using JwtAuth.Api.Core.Entities;
using JwtAuth.Api.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuth.Api.App.Https.Controllers;

[Route("/api/v1/auth")]
[ApiController]
public class AuthController(
    IConfiguration _configuration,
    IAuthService _service) : Controller
{
    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserDto request)
    {
        var user = await _service.RegisterAsync(request);
        
        if (user is null)
        {
            return BadRequest(new
            {
                Message = "User already exist!"
            });
        }

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<object>> Login(UserDto request)
    {
        var result = await _service.LoginAsync(request);
        
        if (result is null)
        {
            return BadRequest(new
            {
                Message = "Username or password is wrong!"
            });
        }

        return Ok(result);
    }

    [Authorize]
    [HttpGet("authenticated-only")]
    public IActionResult AuthenticatedOnlyEndpoint()
    {
        return Ok("You are authenticated!");
    }

    [Authorize(Roles = "Admin,Manager")]
    [HttpGet("admin-only")]
    public IActionResult AdminOnlyEndpoint()
    {
        return Ok("You are authenticated!");
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult<TokenResponseDto>> RefreshToken(
        RefreshTokenRequestDto request)
    {
        var result = await _service.RefreshTokenAsync(request);

        if (result is null || result.AccessToken is null || result.RefreshToken is null)
        {
            return Unauthorized("Invalid refresh token");
        }

        return Ok(result);
    }
}
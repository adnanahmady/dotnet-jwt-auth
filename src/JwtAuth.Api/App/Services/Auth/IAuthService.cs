using JwtAuth.Api.App.Dtos;
using JwtAuth.Api.Core.Entities;

namespace JwtAuth.Api.App.Services.Auth;

public interface IAuthService
{
    Task<User?> RegisterAsync(UserDto request);
    Task<TokenResponseDto?> LoginAsync(UserDto request);
    Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);
}
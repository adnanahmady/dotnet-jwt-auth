using System.ComponentModel.DataAnnotations;

namespace JwtAuth.Api.App.Dtos;

public class UserDto
{
    [Required]
    [MaxLength(255)]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(500)]
    public string Password { get; set; } = string.Empty;
}
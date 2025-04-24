using System.ComponentModel.DataAnnotations;

namespace JwtAuth.Api.Core.Entities;

public class User
{
    public Guid Id { get; set; } = new Guid();
    
    [MaxLength(255)]
    public string Username { get; set; } = string.Empty;

    [MaxLength(500)]
    public string PasswordHash { get; set; } = string.Empty;
}
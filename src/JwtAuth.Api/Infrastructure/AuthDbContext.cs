using JwtAuth.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAuth.Api.Infrastructure;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
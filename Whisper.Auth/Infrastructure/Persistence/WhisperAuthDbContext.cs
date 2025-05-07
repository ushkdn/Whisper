using Microsoft.EntityFrameworkCore;
using Whisper.Auth.Domain.Entities;
using Whisper.Auth.Infrastructure.Persistence.Configurations;

namespace Whisper.Auth.Infrastructure.Persistence;

public sealed class WhisperAuthDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RefreshTokenEntityConfiguration());
    }
}
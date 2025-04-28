using Microsoft.EntityFrameworkCore;
using Whisper.User.Domain.Entities;
using Whisper.User.Infrastructure.Persistence.Configurations;

namespace Whisper.User.Infrastructure.Persistence;

public sealed class WhisperUserDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }
}
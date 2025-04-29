using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whisper.Shared.Infrastructure.Persistence.Configurations.Base;
using Whisper.User.Domain.Entities;
using Whisper.User.Infrastructure.Persistence.Constants;

namespace Whisper.User.Infrastructure.Persistence.Configurations;

public class UserEntityConfiguration : EntityBaseConfiguration<UserEntity>
{
    public override void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        base.Configure(builder);

        builder
                .Property(p => p.Surname)
                .IsRequired()
                .HasColumnName("surname");

        builder
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnName("name");

        builder
                .Property(p => p.Username)
                .HasMaxLength(15)
                .HasColumnName("username");

        builder
                .Property(p => p.Email)
                .IsRequired()
                .HasColumnName("email");

        builder
                .Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(120)
                .HasColumnName("password");

        builder
                .Property(p => p.BirthDay)
                .IsRequired()
                .HasColumnName("birthday");

        builder
                .Property(p => p.IsVerified)
                .HasColumnName("is_verified");

        builder
                .HasIndex(i => i.Email)
                .IsUnique();

        builder
                .HasIndex(i => i.Username)
                .IsUnique();

        builder
                .ToTable(Tables.USERS);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whisper.Auth.Domain.Entities;
using Whisper.Auth.Infrastructure.Persistence.Constants;
using Whisper.Shared.Infrastructure.Persistence.Configurations.Base;

namespace Whisper.Auth.Infrastructure.Persistence.Configurations;

public class RefreshTokenEntityConfiguration : EntityBaseConfiguration<RefreshTokenEntity>
{
    public override void Configure(EntityTypeBuilder<RefreshTokenEntity> builder)
    {
        base.Configure(builder);

        builder
            .Property(p => p.Token)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("refresh_token");

        builder
            .Property(p => p.ExpireDate)
            .IsRequired()
            .HasColumnName("expire_date");

        builder
            .Property(p => p.UserId)
            .IsRequired()
            .HasColumnName("user_id");

        builder.ToTable(Tables.REFRESH_TOKENS);
    }
}
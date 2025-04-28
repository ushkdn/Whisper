using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whisper.Shared.Domain.Entities.Base;

namespace Whisper.Shared.Infrastructure.Persistence.Configurations.Base;

public class EntityBaseConfiguration<TEntity> : EntityConfiguration<TEntity> where TEntity : EntityBase
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.DateCreated)
            .IsRequired()
            .HasColumnName("date_created");

        builder
            .Property(x => x.DateUpdated)
            .IsRequired()
            .HasColumnName("date_updated");
    }
}
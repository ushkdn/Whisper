using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whisper.Shared.Domain.Entities.Base;

namespace Whisper.Shared.Infrastructure.Persistence.Configurations.Base;

public class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
    }
}
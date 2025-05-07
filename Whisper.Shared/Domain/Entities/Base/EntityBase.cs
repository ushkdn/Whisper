using Whisper.Shared.Domain.Entities.Base.Interfaces;

namespace Whisper.Shared.Domain.Entities.Base;

public abstract class EntityBase : Entity, IEntityBase
{
    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }
}
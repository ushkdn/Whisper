using Whisper.Shared.Domain.Entities.Base.Interfaces;

namespace Whisper.Shared.Domain.Entities.Base;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}
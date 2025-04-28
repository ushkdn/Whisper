namespace Whisper.Shared.Domain.Entities.Base;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}
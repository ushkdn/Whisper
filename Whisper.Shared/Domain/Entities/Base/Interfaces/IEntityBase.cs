namespace Whisper.Shared.Domain.Entities.Base;

public interface IEntityBase : IEntity
{
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}
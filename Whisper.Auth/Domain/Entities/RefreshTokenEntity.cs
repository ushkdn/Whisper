using Whisper.Shared.Domain.Entities.Base;

namespace Whisper.Auth.Domain.Entities;

public class RefreshTokenEntity : EntityBase
{
    public string? Token { get; set; }
    public DateTime ExpireDate { get; set; }
    public virtual Guid UserId { get; set; }
}
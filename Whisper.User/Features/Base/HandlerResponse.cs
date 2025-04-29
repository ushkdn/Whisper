namespace Whisper.User.Features.Base;

public class HandlerResponse<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; }
}
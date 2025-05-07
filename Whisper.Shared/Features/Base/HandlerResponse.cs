namespace Whisper.Shared.Features.Base;

public class HandlerResponse<T>
{
    public T? Data { get; init; }
    public string? Message { get; init; }
    public bool Success { get; init; }
}
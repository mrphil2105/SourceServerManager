namespace SourceServerManager.Core;

public class ErrorResult<T> : Result<T>
{
    public ErrorResult(string? message = null) : base(default!, message)
    {
    }

    public override bool Success => false;
}

namespace SourceServerManager.Core;

public class ErrorResult : Result
{
    public ErrorResult(string? message = null) : base(message)
    {
    }

    public override bool Success => false;
}

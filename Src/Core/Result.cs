namespace SourceServerManager.Core;

public abstract class Result
{
    protected Result(string? message)
    {
        Message = message;
    }

    public abstract bool Success { get; }

    public bool Failure => !Success;

    public string? Message { get; }
}

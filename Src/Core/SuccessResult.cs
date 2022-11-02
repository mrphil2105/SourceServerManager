namespace SourceServerManager.Core;

public class SuccessResult : Result
{
    public SuccessResult(string? message = null) : base(message)
    {
    }

    public override bool Success => true;
}

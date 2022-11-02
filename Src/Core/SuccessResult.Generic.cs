using System.Diagnostics.CodeAnalysis;

namespace SourceServerManager.Core;

public class SuccessResult<T> : Result<T>
{
    public SuccessResult([DisallowNull] T data, string? message = null) : base(data, message)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }
    }

    public override bool Success => true;
}

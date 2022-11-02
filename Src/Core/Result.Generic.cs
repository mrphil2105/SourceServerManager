using System.Diagnostics.CodeAnalysis;

namespace SourceServerManager.Core;

public abstract class Result<T> : Result
{
    private readonly T _data;

    protected Result(T data, string? message) : base(message)
    {
        _data = data;
    }

    public T Data => Success
        ? _data
        : throw new InvalidOperationException($"Unable to access {nameof(Data)} when {nameof(Success)} is false.");

    public static Result<T> FromResult(Result result, [DisallowNull] T data)
    {
        return result.Success ? new SuccessResult<T>(data) : new ErrorResult<T>(result.Message);
    }
}

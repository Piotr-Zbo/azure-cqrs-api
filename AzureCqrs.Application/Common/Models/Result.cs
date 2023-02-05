namespace AzureCqrs.Application.Common.Models;

public class Result<TResult>
{
    internal Result(bool succeeded, TResult value, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Value = value;
        Errors = errors.ToArray();
    }

    public bool Succeeded { get; }

    public TResult Value { get; }

    public string[] Errors { get; }

    public static Result<TResult> Success(TResult value)
    {
        return new Result<TResult>(true, value, Array.Empty<string>());
    }

    public static Result<TResult> Failure(IEnumerable<string> errors)
    {
        return new Result<TResult>(false, default(TResult)!, errors);
    }
}
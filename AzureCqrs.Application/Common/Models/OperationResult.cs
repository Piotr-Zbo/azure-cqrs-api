namespace AzureCqrs.Application.Common.Models;

/// <summary>
/// Operation result.
/// </summary>
/// <typeparam name="TResult"></typeparam>
public class OperationResult<TResult>
{
    private OperationResult(bool succeeded, TResult? value, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Value = value;
        Errors = errors.ToArray();
    }

    /// <summary>
    /// Indicate if operation has completed successfully.
    /// </summary>
    public bool Succeeded { get; }

    /// <summary>
    /// Value returned for successful operation, default otherwise.
    /// </summary>
    public TResult? Value { get; }

    /// <summary>
    /// Errors returned.
    /// </summary>
    public string[] Errors { get; }

    /// <summary>
    /// Creates a successful operation result.
    /// </summary>
    /// <returns></returns>
    public static OperationResult<TResult> Success()
    {
        return Success(default);
    }

    /// <summary>
    /// Creates a successful operation result.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static OperationResult<TResult> Success(TResult? value)
    {
        return new OperationResult<TResult>(true, value, Array.Empty<string>());
    }

    /// <summary>
    /// Creates a failed operation result.
    /// </summary>
    /// <returns></returns>
    public static OperationResult<TResult> Failure()
    {
        return new OperationResult<TResult>(false, default, Array.Empty<string>());
    }

    /// <summary>
    /// Creates a failed operation result.
    /// </summary>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static OperationResult<TResult> Failure(IEnumerable<string> errors)
    {
        return new OperationResult<TResult>(false, default, errors);
    }
}
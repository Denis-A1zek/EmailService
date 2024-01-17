namespace EmailService.Web.Common;

public sealed record Result<T>
{
    private Result(T value)
    {
        IsSuccess = true;
        Value = value;
        Error = null;
    }

    private Result(string error)
    {
        IsSuccess = false;
        Value = default(T);
        Error = error;
    }
    public bool IsSuccess { get; }
    public T Value { get; }
    public string Error { get; }

    public static Result<T> Ok(T value)
        => new Result<T>(value);

    public static Result<T> Fail(string error)
        => new Result<T>(error);
}

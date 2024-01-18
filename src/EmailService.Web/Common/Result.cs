namespace EmailService.Web.Common;

/// <summary>
/// Результат операции
/// </summary>
/// <typeparam name="T">Полезные данные</typeparam>
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
    
    /// <summary>
    /// Результат операции, true - успешно, иначе провал
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Полезная нагрузка
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// Сообщение об ошике
    /// </summary>
    public string? Error { get; }


    /// <summary>
    /// Создать успешный результат операции
    /// </summary>
    /// <param name="value">Полезная нагрузка</param>
    /// <returns>Результат операции (успех)</returns>
    public static Result<T> Ok(T? value)
        => new Result<T>(value);

    /// <summary>
    /// Создать неуспешный результат операции
    /// </summary>
    /// <param name="error">Сообщение об ошибке</param>
    /// <returns>Результат операции (провал)</returns>
    public static Result<T> Fail(string error)
        => new Result<T>(error);
}

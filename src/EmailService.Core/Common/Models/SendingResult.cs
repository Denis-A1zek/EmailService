namespace EmailService.Core.Common;

/// <summary>
/// Результат отправки сообщения
/// </summary>
public record class SendingResult
{
    internal SendingResult(SingleMessage message)
    {
        Message = message;
        CreationDate = DateTimeOffset.UtcNow;
        Result = Result.OK;
        FailedMessage = string.Empty;
    }

    internal SendingResult(SingleMessage message, string failedMessage)
    {
        Message = message;
        CreationDate = DateTimeOffset.UtcNow;
        Result = Result.Failed;
        FailedMessage = failedMessage;
    }

    /// <summary>
    /// Отправляемое сообщение
    /// </summary>
    public SingleMessage Message { get; set; }

    /// <summary>
    /// Дата отправки
    /// </summary>
    public DateTimeOffset CreationDate { get; set; }

    /// <summary>
    /// Результат отправки
    /// </summary>
    public Result Result { get; set; }

    /// <summary>
    /// Сообщение об ошибке (пусто в случае успеха)
    /// </summary>
    public string FailedMessage { get; set; }

    /// <summary>
    /// Создает успешный SendingResult 
    /// </summary>
    /// <param name="message">Отправляемое письмо</param>
    /// <returns>Успешный SendingResult</returns>
    public static SendingResult Success(SingleMessage message)
        => new SendingResult(message);

    /// <summary>
    /// Создает неуспешный SendingResult
    /// </summary>
    /// <param name="message">Отправляемое письмо</param>
    /// <param name="failedMessage">Сообщение об ошибке при отправке</param>
    /// <returns>Неуспешный SendingResult</returns>
    public static SendingResult Failed(SingleMessage message, string failedMessage)
        => new SendingResult(message, failedMessage);
}

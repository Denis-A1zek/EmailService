namespace EmailService.Core.Common;


/// <summary>
/// Детали сообщения
/// </summary>
public record MessageDetails : MessageContent
{
    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    public Guid MessageId { get; set; }

    /// <summary>
    /// История отправок
    /// </summary>
    public IEnumerable<SendedLogs> SendedLogs { get; set; }
}

public record SendedLogs
{
    /// <summary>
    /// Идентификатор лога об отправке
    /// </summary>
    public Guid LogId { get; set; }

    /// <summary>
    /// Email получателя
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Дата отправки письма
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Результат отправки 
    /// </summary>
    public string Result { get; set; }

    /// <summary>
    /// Сообщение об ошибке во время отправки
    /// </summary>
    public string FailedMessage { get; set; } 

}

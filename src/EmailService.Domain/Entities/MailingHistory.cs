namespace EmailService.Domain;

public class MailingHistory : Identity
{
    /// <summary>
    /// Email получателя
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Идентификатор сообщения 
    /// </summary>
    public Guid MessageId { get; set; }
    public Message? Message { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedDate { get; set; }
    
    /// <summary>
    /// Результат операции
    /// </summary>
    public string Result { get; set; }

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string? FailedMessage { get; set; }

}

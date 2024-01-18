namespace EmailService.Core.Common;

public record MessageContent
{
    /// <summary>
    /// Тема сообщения
    /// </summary>
    public string Subject { get; init; }

    /// <summary>
    /// Тело сообщения
    /// </summary>
    public string Body { get; init; }
}

public record SingleMessage : MessageContent
{
    /// <summary>
    /// Получатель (e-mail)
    /// </summary>
    public string Recipient { get; set; }
}

public record BulkMessage : MessageContent
{
    /// <summary>
    /// Получатели (e-mail)
    /// </summary>
    public IEnumerable<string> Recipients { get; set; }
}

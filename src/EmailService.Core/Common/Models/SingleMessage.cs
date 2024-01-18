namespace EmailService.Core.Common;

public record MessageContent
{
    public string Subject { get; init; }
    public string Body { get; init; }
}

public record SingleMessage : MessageContent
{
    public string Recipient { get; set; }
}

public record BulkMessage : MessageContent
{
    public IEnumerable<string> Recipients { get; set; }
}

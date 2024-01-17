namespace EmailService.Core.Common;

public record Message
{
    public string Subject { get; init; }
    public string Body { get; init; }
    public IReadOnlyCollection<string> Recipients { get; init; }
}

namespace EmailService.Web.Models;

public record LetterRequest
{
    public string Subject { get; init; }
    public string Body { get; init; }
    public IReadOnlyCollection<string> Recipients { get; init; }
}

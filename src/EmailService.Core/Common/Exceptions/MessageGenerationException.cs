namespace EmailService.Core;

public class MessageGenerationException : Exception
{
    public MessageGenerationException(string? message) : base(message)
    {
    }
}

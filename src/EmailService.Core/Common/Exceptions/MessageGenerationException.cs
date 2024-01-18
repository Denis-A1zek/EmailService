namespace EmailService.Core;

/// <summary>
/// Ошибка при формировании сообщения
/// </summary>
public class MessageGenerationException : Exception
{
    public MessageGenerationException(string? message) : base(message)
    {
    }
}

namespace EmailService.Domain;

public class Message : Identity
{
    /// <summary>
    /// Тема письма
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Тело письма
    /// </summary>
    public string Body { get; set; }
}

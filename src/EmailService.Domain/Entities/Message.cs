namespace EmailService.Domain;

public class Message : Identity
{
    public string Subject { get; set; }
    public string Body { get; set; }
}

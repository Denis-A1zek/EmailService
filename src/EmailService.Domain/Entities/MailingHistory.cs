namespace EmailService.Domain;

public class MailingHistory : Identity
{
    public string Email { get; set; }
    public Guid MessageId { get; set; }
    public Message? Message { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Result { get; set; }
    public string? FailedMessage { get; set; }

}

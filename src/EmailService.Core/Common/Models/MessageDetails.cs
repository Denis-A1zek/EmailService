namespace EmailService.Core.Common;

public record MessageDetails
{
    public Guid MessageId { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public IEnumerable<SendedLogs> SendedLogs { get; set; }
}

public record SendedLogs
{
    public Guid LogId { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Result { get; set; }
    public string FailedMessage { get; set; } 

}

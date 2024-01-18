namespace EmailService.Web.Common.Models;

public class MailRequest
{
    public string Body { get; set; }
    public string Subject { get; set; }
    public IEnumerable<string> Recipients { get; set; }
}

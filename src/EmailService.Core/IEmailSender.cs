using EmailService.Core.Common;

namespace EmailService.Core;

public interface IEmailSender
{
    Task<SendingResult> SendMailAsync(Message message);
}

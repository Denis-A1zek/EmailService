using EmailService.Core.Common;

namespace EmailService.Core;

public interface IEmailSender
{
    Task<SendingResult> SendMailAsync(SingleMessage message);
    public Task<SendingResult[]> SendMailsAsync(BulkMessage bulkMessage);
}

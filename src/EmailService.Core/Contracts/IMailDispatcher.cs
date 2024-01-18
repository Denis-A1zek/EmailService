using EmailService.Core.Common;

namespace EmailService.Core.Contracts;

public interface IMailDispatcher
{
    Task<IEnumerable<MessageDetails>> GetMailsAsync();
    Task<Guid> SendAsync(string subject, string body, IEnumerable<string> recipients);
}

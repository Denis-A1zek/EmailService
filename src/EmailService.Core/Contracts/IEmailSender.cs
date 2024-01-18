using EmailService.Core.Common;

namespace EmailService.Core;

public interface IEmailSender
{
    /// <summary>
    /// Отправляет письмо одному отправителю
    /// </summary>
    /// <param name="message">Контент письма</param>
    /// <returns>Результат отправки</returns>
    Task<SendingResult> SendMailAsync(SingleMessage message);

    /// <summary>
    /// Отправляет письмо группе адресов
    /// </summary>
    /// <param name="bulkMessage">Контент письма</param>
    /// <returns>Результат отправки</returns>
    public Task<SendingResult[]> SendMailsAsync(BulkMessage bulkMessage);
}

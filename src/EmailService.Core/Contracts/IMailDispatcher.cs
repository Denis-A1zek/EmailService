using EmailService.Core.Common;

namespace EmailService.Core.Contracts;

public interface IMailDispatcher
{
    /// <summary>
    /// Получить все детали о сообщении
    /// </summary>
    /// <returns>Детали о сообщении</returns>
    Task<IEnumerable<MessageDetails>> GetMailsAsync();

    /// <summary>
    /// Отправляет письмо и сохраняет результат
    /// </summary>
    /// <param name="subject">Тема</param>
    /// <param name="body">Тело</param>
    /// <param name="recipients">Получатели</param>
    /// <returns>Идентификатор сформированного сообщения в базе</returns>
    Task<Guid> SendAsync(string subject, string body, IEnumerable<string> recipients);
}

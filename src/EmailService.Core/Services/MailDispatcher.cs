using EmailService.Core.Common;
using EmailService.Core.Contracts;
using EmailService.Domain;
using EmailService.Infrastructure;

namespace EmailService.Core.Services;

/// <summary>
/// Диспетчер сообщений
/// </summary>
public class MailDispatcher : IMailDispatcher
{
    private readonly IEmailSender _emailSender;
    public readonly IUnitOfWork _unitOfWork;

    private readonly IRepository<Message> _messageRepository;
    private readonly IRepository<MailingHistory> _mailingHistoryRepository;

    public MailDispatcher(IEmailSender emailSender, IUnitOfWork unitOfWork)
    {
        _emailSender = emailSender;
        _unitOfWork = unitOfWork;

        _messageRepository = _unitOfWork.GetRepository<Message>();
        _mailingHistoryRepository = _unitOfWork.GetRepository<MailingHistory>();
    }

    /// <summary>
    /// Отправляет письмо и сохраняет результат
    /// </summary>
    /// <param name="subject">Тема</param>
    /// <param name="body">Тело</param>
    /// <param name="recipients">Получатели</param>
    /// <returns>Идентификатор сформированного сообщения в базе</returns>
    public async Task<Guid> SendAsync
        (string subject, string body, IEnumerable<string> recipients)
    {
        var sendingResults = await _emailSender
                                    .SendMailsAsync(new BulkMessage()
                                    {
                                        Subject = subject,
                                        Body = body,
                                        Recipients = recipients
                                    });

        var sendingMessage = sendingResults.First().Message;

        var message = new Message()
        {
            Id = Guid.NewGuid(),
            Body = body,
            Subject = subject
        };
        await _messageRepository.InsertAsync(message);
        var mailingHistorys = sendingResults.Select(s =>
        {
            return new MailingHistory()
            {
                Id = Guid.NewGuid(),
                Email = s.Message.Recipient,
                FailedMessage = s.FailedMessage,
                Result = s.Result.ToString(),
                CreatedDate = s.CreationDate.UtcDateTime,
                MessageId = message.Id
            };
        });
        await _mailingHistoryRepository.InsertRangeAsync(mailingHistorys);
        await _unitOfWork.SaveChangesAsync();

        return message.Id;
    }


    /// <summary>
    /// Получить все детали о сообщении
    /// </summary>
    /// <returns>Детали о сообщении</returns>
    public async Task<IEnumerable<MessageDetails>> GetMailsAsync()
    {
        var mailingHistory = await _mailingHistoryRepository.GroupByAsync(m => m.Message);
        return mailingHistory.Select(m => new MessageDetails()
        {
            MessageId = m.Key.Id,
            Subject = m.Key.Subject,
            Body = m.Key.Body,
            SendedLogs = m.Select(l
                => new SendedLogs()
                {
                    LogId = l.Id,
                    Email = l.Email,
                    FailedMessage = l.FailedMessage,
                    Result = l.Result,
                    CreatedDate = l.CreatedDate
                })
        });
    }
}

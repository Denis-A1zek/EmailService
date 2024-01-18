using EmailService.Core.Common;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace EmailService.Core.Services;

public class EmailSender : IEmailSender
{
    private readonly SmtpOptions _smtpOptions;

    private int DegreeOfParallelism => Environment.ProcessorCount * 10;

    public EmailSender(IOptions<SmtpOptions> smtpOptions)
        => _smtpOptions = smtpOptions.Value;

    public async Task<SendingResult> SendMailAsync(Message message)
    {
        using SmtpClient smtp = new();
        try
        {
            var mimeMessage = GenerateMimeMessage(message);
            smtp.Connect(
                _smtpOptions.Host,
                _smtpOptions.Port,
                MailKit.Security.SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(
                _smtpOptions.Username,
                _smtpOptions.Password);

            var result = await smtp.SendAsync(mimeMessage);
        }
        catch (MessageGenerationException messageValidationEx)
        {
            return SendingResult.Failed(message, messageValidationEx.Message);
        }
        finally
        {
            smtp.Disconnect(true);
        }

        return SendingResult.Success(message);
    }

    public Task<SendingResult[]> SendMailsAsync(BulkMessage bulkMessage)
    {
        var _sendingTask = bulkMessage.Recipients
                .AsParallel()
                .WithDegreeOfParallelism(DegreeOfParallelism)
                .Select((recipient, i) =>
                {
                    return SendMailAsync(new Message()
                    {
                        Body = bulkMessage.Body,
                        Subject = bulkMessage.Subject,
                        Recipient = recipient
                    });
                });

        return Task.WhenAll(_sendingTask);
    }

    private MimeMessage GenerateMimeMessage(Message message)
    {
        MimeMessage email = new MimeMessage();

        email.Sender = AddressValidation(_smtpOptions.Username);
        email.To.Add(AddressValidation(message.Recipient));
        email.Subject = message.Subject;
        email.Body = new TextPart(TextFormat.Plain)
        { Text = message.Body };

        return email;
    }

    private MailboxAddress AddressValidation(string address)
    {
        var isAddress = MailboxAddress
            .TryParse(new ParserOptions()
            { AllowAddressesWithoutDomain = false },
                        address,
                        out var result);

        return isAddress ? result
            : throw new MessageGenerationException($"Email: ({address}) is not valid");
    }
}

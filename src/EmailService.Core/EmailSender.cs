using EmailService.Core.Common;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EmailService.Core;

public class EmailSender : IEmailSender
{
    private readonly SmtpOptions _smtpOptions;

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

            await smtp.SendAsync(mimeMessage);
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
    
    private MimeMessage GenerateMimeMessage(Message message) 
    {
        MimeMessage email = new MimeMessage();
        email.Sender = AddressValidation(_smtpOptions.Username);

        email.To.AddRange(message.Recipients.Select(e =>
            AddressValidation(e)
        ));

        email.Subject = message.Subject;

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = message.Body;
        email.Body = bodyBuilder.ToMessageBody();

        return email;
    }

    private MailboxAddress AddressValidation(string address)
    {
        var isAddress = MailboxAddress.TryParse(address, out var result);
        return isAddress ? result 
            : throw new MessageGenerationException();
    } 
}

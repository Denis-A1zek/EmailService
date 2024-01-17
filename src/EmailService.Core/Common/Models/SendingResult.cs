namespace EmailService.Core.Common;

public record class SendingResult
{
    public SendingResult(Message message)
    {
        Message = message;
        CreationDate = DateTimeOffset.UtcNow;
        Result = Result.OK;
        FailedMessage = string.Empty;
    }

    public SendingResult(Message message, string failedMessage)
    {
        Message = message;
        CreationDate = DateTimeOffset.UtcNow;
        Result = Result.Failed;
        FailedMessage = failedMessage;
    }

    public Message Message { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public Result Result { get; set; }
    public string FailedMessage { get; set; }

    public static SendingResult Success(Message message)
        => new SendingResult(message);

    public static SendingResult Failed(Message message, string failedMessage)
        => new SendingResult(message, failedMessage);
}

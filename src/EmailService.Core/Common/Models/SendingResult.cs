namespace EmailService.Core.Common;

public record class SendingResult
{
    public SendingResult(SingleMessage message)
    {
        Message = message;
        CreationDate = DateTimeOffset.UtcNow;
        Result = Result.OK;
        FailedMessage = string.Empty;
    }

    public SendingResult(SingleMessage message, string failedMessage)
    {
        Message = message;
        CreationDate = DateTimeOffset.UtcNow;
        Result = Result.Failed;
        FailedMessage = failedMessage;
    }

    public SingleMessage Message { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public Result Result { get; set; }
    public string FailedMessage { get; set; }

    public static SendingResult Success(SingleMessage message)
        => new SendingResult(message);

    public static SendingResult Failed(SingleMessage message, string failedMessage)
        => new SendingResult(message, failedMessage);
}

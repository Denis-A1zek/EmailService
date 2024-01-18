using FluentValidation;

namespace EmailService.Web.Common.Models;

public class MailRequest
{
    /// <summary>
    /// Тема сообщения
    /// </summary>
    public string Subject { get; init; }
    
    /// <summary>
    /// Тело сообщения
    /// </summary>
    public string Body { get; init; }

    /// <summary>
    /// Получатели
    /// </summary>
    public IEnumerable<string> Recipients { get; init; }
}

/// <summary>
/// Правила валидации модели MailRequest
/// </summary>
public class MailRequestValidator : AbstractValidator<MailRequest>
{
    public MailRequestValidator()
    {
        RuleFor(m => m.Recipients).ForEach(m => m.EmailAddress().WithMessage("Invalid email address"));
        RuleFor(m => m.Recipients).NotNull().NotEmpty().Must(m => m.Count() > 0).WithMessage("Email > 0");
        RuleFor(m => m.Subject).NotEmpty().MinimumLength(2).MaximumLength(64).WithMessage("Email > 0"); ;
        RuleFor(m => m.Body).NotEmpty().MinimumLength(2).MaximumLength(512).WithMessage("Email > 0");
    }
}

using EmailService.Core.Contracts;
using EmailService.Web.Common.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Web.Controllers;

[ApiController]
[Route("api/mails")]
public class MailsController : ControllerBase
{
    private readonly IMailDispatcher _mailDispatcher;
    private readonly IValidator<MailRequest> _validator;

    public MailsController(IMailDispatcher mailDispatcher, IValidator<MailRequest> validator)
        => (_mailDispatcher,_validator) = (mailDispatcher, validator);

    /// <summary>
    /// Получить все сообщения и историю отправки
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<string>> GetAll()
        => Ok(await _mailDispatcher.GetMailsAsync());

    /// <summary>
    /// Отпраляет сообщение получателям и сохраняет историю отправки
    /// </summary>
    /// <param name="mailRequest">Параметры сообщения</param>
    /// <returns></returns>
    /// <exception cref="ValidationException">Ошибка валидации</exception>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(MailRequest mailRequest)
    {
        var validationResult = _validator.Validate(mailRequest);
        if (!validationResult.IsValid)
            throw new ValidationException("Ошибка валидации", validationResult.Errors);

        return Ok(await _mailDispatcher.SendAsync(
                mailRequest.Subject,
                mailRequest.Body,
                mailRequest.Recipients));
    }
}

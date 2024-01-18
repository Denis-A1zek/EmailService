using EmailService.Core;
using EmailService.Core.Common;
using EmailService.Core.Contracts;
using EmailService.Domain;
using EmailService.Infrastructure;
using EmailService.Web.Common;
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

    [HttpGet]
    public async Task<ActionResult<string>> GetAll()
        => Ok(await _mailDispatcher.GetMailsAsync());

    [HttpPost]
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

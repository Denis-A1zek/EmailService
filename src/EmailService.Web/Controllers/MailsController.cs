using EmailService.Core;
using EmailService.Core.Common;
using EmailService.Core.Contracts;
using EmailService.Domain;
using EmailService.Infrastructure;
using EmailService.Web.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Web.Controllers;

[ApiController]
[Route("api/mails")]
public class MailsController : ControllerBase
{
    private readonly IMailDispatcher _mailDispatcher;

    public MailsController(IMailDispatcher mailDispatcher)
        => _mailDispatcher = mailDispatcher;

    [HttpGet]
    public async Task<ActionResult<string>> GetAll()
    {
        return Ok(await _mailDispatcher.GetMailsAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Post(MailRequest mailRequest)
        => Ok(await _mailDispatcher.SendAsync(
                mailRequest.Subject,
                mailRequest.Body,
                mailRequest.Recipients));
}

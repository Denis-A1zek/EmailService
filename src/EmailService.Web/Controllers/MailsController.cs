using EmailService.Core;
using EmailService.Core.Common;
using EmailService.Web.Common;
using EmailService.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace EmailService.Web.Controllers;

[ApiController]
[Route("api/mails")]
public class MailsController : ControllerBase
{
    private readonly IEmailSender _emailSender;

    public MailsController(IEmailSender emailSender)
        => _emailSender = emailSender;

    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
        
        return Ok("dfs");
    }

    [HttpPost]
    public async Task<IActionResult> Post(Message message)
    {
        var result = await _emailSender.SendMailAsync(message);

        return result.Result is Core.Common.Result.Failed ? 
            BadRequest(Result<int>.Fail(result.FailedMessage)) 
            : Ok(1);
    }
}

using EmailService.Core;
using EmailService.Core.Common;
using EmailService.Web.Common.Models;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> Post(MailRequest mailRequest)
    {
        var sendingResults = await _emailSender
                                    .SendMailsAsync(new BulkMessage()
                                    {
                                        Subject = mailRequest.Subject,
                                        Body = mailRequest.Body,
                                        Recipients = mailRequest.Recipients
                                    });


        return Ok(1);
    }
}

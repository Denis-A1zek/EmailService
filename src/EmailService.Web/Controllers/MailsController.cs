using EmailService.Core;
using EmailService.Core.Common;
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
    public async Task<ActionResult<string>> Post(Message message)
    {
        var result = await _emailSender.SendMailAsync(message);

        return Ok("dfs");
    }
}

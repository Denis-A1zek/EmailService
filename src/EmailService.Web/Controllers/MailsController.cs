using EmailService.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace EmailService.Web.Controllers;

[ApiController]
[Route("api/mails")]
public class MailsController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
        
        return Ok("dfs");
    }
}

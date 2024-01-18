namespace EmailService.Core;

/// <summary>
/// Настройки SMPT
/// </summary>
public class SmtpOptions
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}


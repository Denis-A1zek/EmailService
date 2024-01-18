using EmailService.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailService.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEmailSender, EmailSender>();

        services.AddOptions<SmtpOptions>().BindConfiguration(nameof(SmtpOptions));

        return services;
    }
}

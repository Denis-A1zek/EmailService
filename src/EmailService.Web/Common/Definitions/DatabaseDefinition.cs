using EmailService.Infrastructure;

namespace EmailService.Web.Common.Definitions;

public static class DatabaseDenition
{
    public static void MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<PostgreDbContext>();
        InfrastuctureExtensions.MigrateDatabase(context);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailService.Infrastructure;

public static class InfrastuctureExtensions
{
    public static IServiceCollection AddPostgreSql(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameof(PostgreDbContext));
       
        services.AddDbContext<PostgreDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static void MigrateDatabase(PostgreDbContext context)
    {
        context.Database.Migrate();
    }
}

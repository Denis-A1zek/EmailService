using Microsoft.EntityFrameworkCore;

namespace EmailService.Infrastructure;

public class PostgreDbContext : DbContext
{
    public PostgreDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgreDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

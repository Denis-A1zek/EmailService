using EmailService.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailService.Infrastructure.Configuration;

internal class MailingHistoryTypeConfiguration : IdentityTypeConfiguration<MailingHistory>
{
    protected override void AddConfigure(EntityTypeBuilder<MailingHistory> builder)
    {
        builder.Property(s => s.Result).HasConversion<string>();
    }
}

using EmailService.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailService.Infrastructure.Configuration;

internal class MessageTypeConfiguration : IdentityTypeConfiguration<Message>
{
    protected override void AddConfigure(EntityTypeBuilder<Message> builder)
    {
        
    }
}

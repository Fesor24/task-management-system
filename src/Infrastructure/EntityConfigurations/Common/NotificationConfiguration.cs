using Domain.Entities.Common.Notification;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Common;
public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications", "com");

        builder.HasKey(x => x.NotificationId);

        builder.Property(x => x.NotificationStatus)
            .HasConversion(
            x => x.ToString(),
            value => (NotificationStatus)Enum.Parse(typeof(NotificationStatus), value)
            );

        builder.Property(x => x.Message)
            .IsRequired()
            .HasMaxLength(400);
    }
}

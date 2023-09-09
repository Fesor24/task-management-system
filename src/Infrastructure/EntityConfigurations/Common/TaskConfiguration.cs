using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskEntity = Domain.Entities.Common.Task;

namespace Infrastructure.EntityConfigurations.Common;
public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable(nameof(Task), "com");
        builder.Property(x => x.Title).IsRequired().HasColumnName("Title");
        builder.Property(x => x.Status).HasColumnName("Status");
        builder.Property(x => x.Priority).HasColumnName("Priority");
        builder.Property(x => x.DueDate).HasColumnName("DueDate");
        builder.Property(x => x.Description).IsRequired(false).HasColumnName("Description");
    }
}

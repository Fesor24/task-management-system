using Domain.Entities.Common.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskEntity = Domain.Entities.Common.Task.Task;
using Domain.Entities.Common.Project;

namespace Infrastructure.EntityConfigurations.Common;
public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("Tasks", "com");

        builder.HasKey(x => x.TaskId);

        builder.OwnsOne(x => x.Body, bodyBuilder =>
        {
            bodyBuilder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            bodyBuilder.Property(x => x.Description).HasMaxLength(700).IsRequired();
        });
    }
}

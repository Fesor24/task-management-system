using Domain.Entities.Common.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.EntityConfigurations.Common;
public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("Tasks", "com");

        builder.HasKey(x => x.TaskId);

        builder.Property(x => x.TaskId).HasConversion(
            task => task.Value,
            value => new TaskId(value));

        builder.Property(x => x.DueDate).HasConversion(
            dueDate => dueDate.Value,
            value => DueDate.Create(value)
            );
    }
}

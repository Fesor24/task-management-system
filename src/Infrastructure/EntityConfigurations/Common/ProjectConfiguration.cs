using Domain.Entities.Common.Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Common;
public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects", "com");
        builder.HasKey(x => x.ProjectId);

        builder.HasMany(prj => prj.Tasks)
            .WithOne(tsk => tsk.Project)
            .HasForeignKey(tsk => tsk.ProjectId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

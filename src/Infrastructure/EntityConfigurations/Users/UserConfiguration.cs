using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Users;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "usr");

        builder.HasKey(x => x.UserId);

        builder.HasMany(x => x.Tasks)
            .WithOne(tsk => tsk.User)
            .HasForeignKey(tsk => tsk.UserId)
            .IsRequired(false);

        builder.OwnsOne(x => x.UserInfo, userBuilder =>
        {
            userBuilder.Property(x => x.Email).IsRequired();
            userBuilder.Property(x => x.Name).IsRequired();
        });
    }
}

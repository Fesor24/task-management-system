using Domain.Entities;
using Domain.Entities.Common.Project;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskEntity = Domain.Entities.Common.Task.Task;

namespace Infrastructure.Context;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var tracker in ChangeTracker.Entries<AuditableEntity>())
        {
            tracker.Entity.UpdatedAt = DateTimeOffset.UtcNow;

            if(tracker.State == EntityState.Added)
            {
                tracker.Entity.CreatedAt = DateTimeOffset.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();
    public DbSet<Project> Projects => Set<Project>();
}

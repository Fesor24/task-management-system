using Domain.Repositories;

namespace Domain.Context;
public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

    Task<bool> Complete(CancellationToken cancellationToken = default);
}

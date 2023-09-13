using Domain.Context;
using Domain.Repositories;
using Infrastructure.Repositories;
using System.Collections;

namespace Infrastructure.Context;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private Hashtable _repositories;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Complete(CancellationToken cancellationToken = default) =>
        await _context.SaveChangesAsync() > 0;

    public void Dispose()
    {
        _context.Dispose();
    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        _repositories ??= new Hashtable();

        var key = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(key))
        {
            var repositoryType = typeof(GenericRepository<>);

            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

            _repositories.Add(key, repositoryInstance);
        }

        return (IGenericRepository<TEntity>) _repositories[key];
    }
}

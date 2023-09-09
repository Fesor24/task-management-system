using Domain.Abstractions;

namespace Domain.Repositories;
public interface IGenericRepository<T> where T: class
{
    Task<IEnumerable<T>> GetAllAsync(ISpecification<T> spec);

    Task<T> GetAsync(ISpecification<T> spec);

    Task AddAsync(T entity);

    bool Update(T entity);

    bool Delete(T entity);
}

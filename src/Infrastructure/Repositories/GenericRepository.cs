using Domain.Abstractions;
using Domain.Repositories;
using Infrastructure.Context;
using Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity) => 
        await _context.Set<T>().AddAsync(entity);

    public bool Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        return true;
    }

    public async Task<IEnumerable<T>> GetAllAsync(ISpecification<T> spec) =>
        await ApplySpecification(spec).ToListAsync();

    public async Task<T> GetAsync(ISpecification<T> spec) =>
        await ApplySpecification(spec).FirstOrDefaultAsync();
   
    public bool Update(T entity)
    {
        _context.Attach(entity);

        _context.Entry(entity).State = EntityState.Modified;

        return true;
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec) =>
        SpecificationEvaluator.GetQuery(_context.Set<T>().AsQueryable(), spec);
}

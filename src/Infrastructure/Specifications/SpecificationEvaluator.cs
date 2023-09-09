using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Specifications;
public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> query, ISpecification<TEntity> spec) 
        where TEntity : class
    {
        IQueryable<TEntity> queryToReturn = query;

        if(spec.Criteria is not null)
        {
            queryToReturn = queryToReturn.Where(spec.Criteria);
        }

        if(spec.OrderBy is not null)
        {
            queryToReturn = queryToReturn.OrderBy(spec.OrderBy);
        }

        if(spec.OrderByDesc is not null) 
        {
            queryToReturn = queryToReturn.OrderByDescending(spec.OrderByDesc);
        }

        queryToReturn = spec.Includes.Aggregate(queryToReturn, (current, include) => current.Include(include));

        return queryToReturn;
    }
}

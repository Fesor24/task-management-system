using Domain.Abstractions;
using System.Linq.Expressions;

namespace Infrastructure.Specifications;
public class BaseSpecification<T> : ISpecification<T> where T : class
{
    public BaseSpecification()
    {
        
    }

    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; private set; }

    public Expression<Func<T, object>> OrderBy { get; private set; }

    public Expression<Func<T, object>> OrderByDesc { get; private set; }

    public List<Expression<Func<T, object>>> Includes { get; private set; } = new();

    protected void AddInclude(Expression<Func<T, object>> include) => 
        Includes.Add(include);

    protected void SetOrderBy(Expression<Func<T, object>> orderBy) => 
        OrderBy = orderBy;

    protected void SetOrderByDesc(Expression<Func<T, object>> orderByDesc) => 
        OrderByDesc = orderByDesc;
}

using FluentValidation;
using MediatR;
using Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Mediator;
public class MediatorValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public MediatorValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        var errors = _validators
            .Select(x => x.Validate(request))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToList();

        if(errors.Any())
        {
            var validationErrors = errors.Select(x => x.ErrorMessage);
            throw new ApiFluentValidationException(JsonSerializer.Serialize(validationErrors));
        }

        return await next();
    }
}

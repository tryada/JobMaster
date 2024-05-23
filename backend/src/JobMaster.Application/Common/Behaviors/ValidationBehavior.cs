using FluentValidation;
using MediatR;

namespace JobMaster.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator = null)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    private readonly IValidator<TRequest>? _validator = validator;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator != null)
        {
            await _validator.ValidateAndThrowAsync(request);
        }

        return await next();
    }
}
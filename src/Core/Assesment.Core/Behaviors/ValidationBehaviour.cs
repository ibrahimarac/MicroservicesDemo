using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Assesment.Core.Results;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Assesment.Core.Behaviors
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse:Response
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var validatonErrorResponse = new DataResponse<IEnumerable<ValidationFailure>>(failures, false);
                    return validatonErrorResponse as TResponse;
                }
                    
            }
            return await next();
        }
    }
}
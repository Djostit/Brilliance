using FluentValidation;
using MediatR;

namespace Brilliance.API.Behavior
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>>? _validators;
        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>>? validators = null)
            => _validators = validators;
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators != null)
            {
                var context = new ValidationContext<TRequest>(request);
                var validationTasks = _validators.Select(v => v.ValidateAsync(context, cancellationToken));

                foreach (var validationTask in validationTasks)
                {
                    var validationResult = await validationTask;

                    if (!validationResult.IsValid)
                    {
                        var failures = validationResult.Errors.Where(f => f != null).ToList();
                        throw new ValidationException(failures);
                    }
                }
            }

            return await next();
        }
    }
}

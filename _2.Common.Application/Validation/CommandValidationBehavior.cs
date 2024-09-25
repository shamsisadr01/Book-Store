using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using _2.Common.Application.Validation;
using C2.Application.Validation;
using Common_2.Application.Validation;
using FluentValidation;
using L2.Common.Application.Validation;
using MediatR;

namespace Common.L2.Application.Validation
{
	public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var errors = _validators
				.Select(v => v.Validate(request))
				.SelectMany(result => result.Errors)
				.Where(error => error != null)
				.ToList();

			if (errors.Any())
			{
				var errorBuilder = new StringBuilder();

				foreach (var error in errors)
				{
					errorBuilder.AppendLine(error.ErrorMessage);
				}

				throw new InvalidCommandException(errorBuilder.ToString(), null);
			}
			var response = await next();
			return response;
		}
	}
}
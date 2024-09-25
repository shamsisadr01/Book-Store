using _2.Common.Application.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace _2.Common.Application
{
	public class CommonBootstrapper
	{
		public static void Init(IServiceCollection service)
		{
			service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
		}
	}
}
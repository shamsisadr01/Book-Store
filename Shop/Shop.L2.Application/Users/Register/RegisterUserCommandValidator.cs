using Common.L2.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Users.Register
{
	public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
	{
		public RegisterUserCommandValidator()
		{
			RuleFor(f => f.Password)
			.NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
			.NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
			.MinimumLength(4).WithMessage("کلمه عبور باید بشتر از 4 کارکتر باشد");
		}
    }
}

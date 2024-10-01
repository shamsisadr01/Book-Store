using Common.L2.Application.Validation;
using Common.L2.Application.Validation.FluentValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Users.Create
{
	public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
	{
		public CreateUserCommandValidator()
		{
			RuleFor(r => r.PhoneNumber)
				.ValidPhoneNumber();

			RuleFor(r => r.Email)
				.EmailAddress().WithMessage("ایمیل نامعتبر است");

			RuleFor(f => f.Password)
				.NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
				.NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
				.MinimumLength(4).WithMessage("کلمه عبور باید بشتر از 4 کارکتر باشد");
		}
	}
}

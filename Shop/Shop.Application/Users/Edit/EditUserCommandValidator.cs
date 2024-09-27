using Common.L2.Application.Validation.FluentValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Users.Edit
{
	public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
	{
		public EditUserCommandValidator()
		{
			RuleFor(r => r.PhoneNumber)
				.ValidPhoneNumber();

			RuleFor(r => r.Email)
				.EmailAddress().WithMessage("ایمیل نامعتبر است");


			RuleFor(f => f.Avatar)
				.JustImageFile();
		}
	}
}

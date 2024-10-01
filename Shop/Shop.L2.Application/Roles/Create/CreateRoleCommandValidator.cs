using Common.L2.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Roles.Create
{
	public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
	{
		public CreateRoleCommandValidator()
		{
			RuleFor(r => r.Title)
				.NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
		}
	}
}

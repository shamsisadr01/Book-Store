using Common.L2.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Roles.Edit
{
	public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
	{
		public EditRoleCommandValidator()
		{
			RuleFor(r => r.Title)
				.NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
		}
	}
}

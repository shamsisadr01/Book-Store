using Common.L2.Application.Validation;
using Common.L2.Application.Validation.FluentValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Products.AddImage
{
	public class AddProductImageCommandValidator : AbstractValidator<AddProductImageCommand>
	{
		public AddProductImageCommandValidator()
		{
			RuleFor(b => b.ImageFile)
				.NotNull().WithMessage(ValidationMessages.required("عکس"))
				.JustImageFile();

			RuleFor(b => b.Sequence)
				.GreaterThanOrEqualTo(0);
		}
	}
}

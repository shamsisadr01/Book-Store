using Common.L2.Application.Validation.FluentValidations;
using Common.L2.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.SiteEntities.Sliders.Edit
{
	public class EditSliderCommandValidator : AbstractValidator<EditSliderCommand>
	{
		public EditSliderCommandValidator()
		{
			RuleFor(r => r.ImageFile)
				.JustImageFile();

			RuleFor(r => r.Link)
				.NotNull()
				.NotEmpty().WithMessage(ValidationMessages.required("لینک"));

			RuleFor(r => r.Title)
				.NotNull()
				.NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
		}
	}
}

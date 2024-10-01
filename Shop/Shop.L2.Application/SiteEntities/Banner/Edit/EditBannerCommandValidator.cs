using Common.L2.Application.Validation;
using Common.L2.Application.Validation.FluentValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.SiteEntities.Banner.Edit
{
	public class EditBannerCommandValidator : AbstractValidator<EditBannerCommand>
	{
        public EditBannerCommandValidator()
        {
			RuleFor(r => r.ImageFile)
			.NotNull().WithMessage(ValidationMessages.required("عکس"))
			.JustImageFile();

			RuleFor(r => r.Link)
				.NotNull()
				.NotEmpty().WithMessage(ValidationMessages.required("لینک"));
		}
    }
}

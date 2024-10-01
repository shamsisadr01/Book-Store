using Common.L2.Application.Validation;
using Common.L2.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.L2.Application.SiteEntities.Banner.Create
{
	public class CreateBannerCommandValidator : AbstractValidator<CreateBannerCommand>
	{
		public CreateBannerCommandValidator()
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

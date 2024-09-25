using Common.L2.Application.Validation;
using FluentValidation;

namespace Shop.L2.Application.Categories.Create
{
	public class CreateCategroyCommandValidator : AbstractValidator<CreateCategroyCommand>
	{
		public CreateCategroyCommandValidator()
		{
			RuleFor(category => category.title)
				.NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
			RuleFor(category => category.slug)
			.NotNull().NotEmpty().WithMessage(ValidationMessages.required("اسلاگ"));
		}
	}
}

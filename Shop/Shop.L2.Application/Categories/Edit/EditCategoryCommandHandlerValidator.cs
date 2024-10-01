using Common.L2.Application.Validation;
using FluentValidation;

namespace Shop.L2.Application.Categories.Edit
{
	public class EditCategoryCommandHandlerValidator : AbstractValidator<EditCategoryCommand>
	{
		public EditCategoryCommandHandlerValidator()
		{
			RuleFor(category => category.title)
				.NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
			RuleFor(category => category.slug)
			.NotNull().NotEmpty().WithMessage(ValidationMessages.required("اسلاگ"));
		}
	}
}

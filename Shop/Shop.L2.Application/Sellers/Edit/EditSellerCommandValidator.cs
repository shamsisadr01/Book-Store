using Common.L2.Application.Validation;
using Common.L2.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.L2.Application.Sellers.Edit
{
	public class EditSellerCommandValidator : AbstractValidator<EditSellerCommand>
	{
		public EditSellerCommandValidator()
		{
			RuleFor(r => r.ShopName)
				.NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

			RuleFor(r => r.ShopName)
				.NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
				.ValidNationalId();
		}
	}
}

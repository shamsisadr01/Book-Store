using FluentValidation;

namespace Shop.L2.Application.Orders.DecreaseItemCount
{
	public class DecreaseOrderItemCountCommandValidator : AbstractValidator<DecreaseOrderItemCountCommand>
	{
		public DecreaseOrderItemCountCommandValidator()
		{
			RuleFor(orderItem => orderItem.count).GreaterThanOrEqualTo(1)
			.WithMessage("تعداد باید بیشتر از 0 باشد.");
		}
	}
}

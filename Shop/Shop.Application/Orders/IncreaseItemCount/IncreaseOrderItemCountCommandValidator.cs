using FluentValidation;

namespace Shop.L2.Application.Orders.IncreaseItemCount
{
	public class IncreaseOrderItemCountCommandValidator : AbstractValidator<IncreaseOrderItemCountCommand>
	{
        public IncreaseOrderItemCountCommandValidator()
        {
			RuleFor(orderItem => orderItem.count).GreaterThanOrEqualTo(1)
				.WithMessage("تعداد باید بیشتر از 0 باشد.");
        }
    }
}

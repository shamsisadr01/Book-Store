using FluentValidation;

namespace Shop.L2.Application.Orders.AddItem
{
	public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
	{
		public AddOrderItemCommandValidator()
		{
			RuleFor(orderItem => orderItem.Count)
				.GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
		}
	}
}

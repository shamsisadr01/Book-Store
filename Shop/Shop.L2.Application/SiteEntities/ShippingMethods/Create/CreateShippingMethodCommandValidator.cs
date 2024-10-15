using FluentValidation;

namespace Shop.L2.Application.SiteEntities.ShippingMethods.Create;

public class CreateShippingMethodCommandValidator : AbstractValidator<CreateShippingMethodCommand>
{
    public CreateShippingMethodCommandValidator()
    {
        RuleFor(f => f.title)
            .NotNull().NotEmpty();
    }
}
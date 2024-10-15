using FluentValidation;

namespace Shop.L2.Application.SiteEntities.ShippingMethods.Edit;

public class EditShippingMethodCommandValidator : AbstractValidator<EditShippingMethodCommand>
{
    public EditShippingMethodCommandValidator()
    {
        RuleFor(f => f.Title)
            .NotNull().NotEmpty();
    }
}
using Common.L2.Application.Validation;
using Common.L2.Application.Validation.FluentValidations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Users.AddAddress
{
	public class AddUserAddressCommandValidator : AbstractValidator<AddUserAddressCommand>
	{
        public AddUserAddressCommandValidator()
        {
			RuleFor(f => f.City)
		  .NotEmpty().WithMessage(ValidationMessages.required("شهر"));

			RuleFor(f => f.Shire)
				.NotEmpty().WithMessage(ValidationMessages.required("استان"));

			RuleFor(f => f.Name)
				.NotEmpty().WithMessage(ValidationMessages.required("نام"));

			RuleFor(f => f.Family)
				.NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));

			RuleFor(f => f.NationalCode)
				.NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
				.ValidNationalId();

			RuleFor(f => f.PostalAddress)
				.NotEmpty().WithMessage(ValidationMessages.required("آدرس پستی"));

			RuleFor(f => f.PostalCode)
				.NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));
		}
    }
}

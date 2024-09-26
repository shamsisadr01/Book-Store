using Common.L2.Application.Validation.FluentValidations;
using Common.L2.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Products.Edit
{
	public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
	{
		public EditProductCommandValidator() 
		{
			RuleFor(r => r.Title)
	   .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

			RuleFor(r => r.Slug)
			   .NotEmpty().WithMessage(ValidationMessages.required("اسلاگ"));

			RuleFor(r => r.Description)
			   .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

			RuleFor(r => r.ImageFile)
			   .JustImageFile();
		}
	}
}

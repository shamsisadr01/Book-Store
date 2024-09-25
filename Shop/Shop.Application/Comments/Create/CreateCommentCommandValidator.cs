using Common.L2.Application.Validation;
using FluentValidation;

namespace Shop.L2.Application.Comments.Create
{
	public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
	{
        public CreateCommentCommandValidator()
        {
			RuleFor(comment => comment.text).NotNull()
				.MinimumLength(5).WithMessage(ValidationMessages.minLength("نظر",5));
        }
    }
}

using Common.L2.Application;
using Shop.L1.Domain.Comment_Aggregate.Repositories;

namespace Shop.L2.Application.Comments.Edit
{
	public class CreateCommentCommandHandler : IBaseCommandHandler<EditCommentCommand>
	{
		private readonly ICommentRepository _commentRepository;

		public CreateCommentCommandHandler(ICommentRepository commentRepository)
		{
			_commentRepository = commentRepository;
		}

		public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
		{
			var comment = await _commentRepository.GetTracking(request.commentId);
			if (comment == null || request.userId != comment.UserId)
				return OperationResult.NotFound();

			comment.Edit(request.text);
			await _commentRepository.Save();
			return OperationResult.Success();
		}
	}

}

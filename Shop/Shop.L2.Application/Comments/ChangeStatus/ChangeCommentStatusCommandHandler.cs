using Common.L2.Application;
using Shop.L1.Domain.Comment_Aggregate.Repositories;

namespace Shop.L2.Application.Comments.ChangeStatus
{
	public class ChangeCommentStatusCommandHandler : IBaseCommandHandler<ChangeCommentStatusCommand>
	{
		private readonly ICommentRepository _commentRepository;

		public ChangeCommentStatusCommandHandler(ICommentRepository commentRepository)
		{
			_commentRepository = commentRepository;
		}

		public async Task<OperationResult> Handle(ChangeCommentStatusCommand request, CancellationToken cancellationToken)
		{
			var comment = await _commentRepository.GetTracking(request.id);
			if (comment == null)
				return OperationResult.NotFound();

			comment.ChangeStatus(request.ChangeStatus);
			await _commentRepository.Save();
			return OperationResult.Success();
		}
	}
}

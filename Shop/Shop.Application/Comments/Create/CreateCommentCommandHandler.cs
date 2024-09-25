using Common.L2.Application;
using Shop.L1.Domain.Comment_Aggregate;
using Shop.L1.Domain.Comment_Aggregate.Repositories;

namespace Shop.L2.Application.Comments.Create
{
	public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
	{
		private readonly ICommentRepository _commentRepository;

		public CreateCommentCommandHandler(ICommentRepository commentRepository)
		{
			_commentRepository = commentRepository;
		}

		public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
		{
			var commnet = new Comment(request.userId, request.productId, request.text);
			await _commentRepository.Add(commnet);
			await _commentRepository.Save();

			return OperationResult.Success();
		}
	}
}

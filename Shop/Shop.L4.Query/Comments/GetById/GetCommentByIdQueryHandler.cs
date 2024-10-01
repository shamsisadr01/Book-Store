using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Comments.DTOs;

namespace Shop.L4.Query.Comments.GetById
{
	public class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto?>
	{
		private readonly StoreContext _context;

		public GetCommentByIdQueryHandler(StoreContext context)
		{
			_context = context;
		}

		public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
		{
			var comment = await _context.Comments.FirstOrDefaultAsync(f => f.Id == request.commentId, cancellationToken: cancellationToken);

			return comment.Map();
		}
	}
}

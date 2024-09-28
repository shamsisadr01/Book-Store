using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Comments.GetById
{
	public record GetCommentByIdQuery(long commentId) : IQuery<CommentDto>;

	public class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto>
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

using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Comments.GetByFilter
{
	internal class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
	{
		private readonly StoreContext _context;

		public GetCommentByFilterQueryHandler(StoreContext context)
		{
			_context = context;
		}

		public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
		{
			var @params = request.FilterParams;

			var result = _context.Comments.OrderByDescending(d => d.CreationDate).AsQueryable();


			if (@params.ProductId != null)
				result = result.Where(r => r.ProductId == @params.ProductId);

			if (@params.CommentStatus != null)
				result = result.Where(r => r.Status == @params.CommentStatus);

			if (@params.UserId != null)
				result = result.Where(r => r.UserId == @params.UserId);

			if (@params.StartDate != null)
				result = result.Where(r => r.CreationDate.Date >= @params.StartDate.Value.Date);

			if (@params.EndDate != null)
				result = result.Where(r => r.CreationDate.Date <= @params.EndDate.Value.Date);



			var skip = (@params.PageId - 1) * @params.Take;
			var model = new CommentFilterResult()
			{
				Data = await result.Skip(skip).Take(@params.Take)
					.Select(comment => comment.MapFilterComment())
					.ToListAsync(cancellationToken),
				FilterParams = @params
			};
			model.GeneratePaging(result, @params.Take, @params.PageId);
			return model;
		}
	}
}

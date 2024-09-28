using Common.L4.Query;
using Shop.L4.Query.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Comments.GetByFilter
{
	public class GetCommentByFilterQuery : QueryFilter<CommentFilterResult, CommentFilterParams>
	{
		public GetCommentByFilterQuery(CommentFilterParams filterParams) : base(filterParams)
		{
		}
	}
}

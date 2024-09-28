

using Common.L4.Query;
using Common.L4.Query.BaseFilter;
using Common.L4.Query.Filter;
using Shop.L1.Domain.Comment_Aggregate;

namespace Shop.L4.Query.Comments.DTOs
{
	public class CommentDto : BaseDto
	{
		public long UserId { get;  set; }
		public string UserFullName { get; set; }
		public long ProductId { get;  set; }
		public string ProductTitle { get; set; }
		public string Text { get;  set; }
		public CommentStatus Status { get;  set; }
	
	}

	public class CommentFilterParams : BaseFilterParam
	{
		public long? UserId { get; set; }
		public long? ProductId { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public CommentStatus? CommentStatus { get; set; }
	}

	public class CommentFilterResult : BaseFilter<CommentDto, CommentFilterParams>
	{

	}
}

using Common.L2.Application;
using Shop.L1.Domain.Comment_Aggregate.Enums;

namespace Shop.L2.Application.Comments.ChangeStatus
{
	public record ChangeCommentStatusCommand(long id, CommentStatus ChangeStatus) : IBaseCommand;
}

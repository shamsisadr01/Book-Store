using Common.L2.Application;
using Shop.L1.Domain.Comment_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Comments.ChangeStatus
{
	public record ChangeCommentStatusCommand(long id, CommentStatus ChangeStatus) : IBaseCommand;
}

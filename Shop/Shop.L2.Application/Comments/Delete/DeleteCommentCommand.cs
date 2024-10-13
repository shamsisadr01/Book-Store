using Common.L2.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Comments.Delete
{
    public record DeleteCommentCommand(long CommentId, long UserId) : IBaseCommand;
}

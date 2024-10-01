using Common.L2.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Comments.Create
{
	public record CreateCommentCommand(long userId,long productId,string text) : IBaseCommand;
}

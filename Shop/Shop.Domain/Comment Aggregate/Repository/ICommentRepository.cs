using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shop.Domain.Comment_Aggregate.Repositories
{
	public interface ICommentRepository : IBaseRepository<Comment>
	{
		Task DeleteAndSave(Comment comment);
	}
}

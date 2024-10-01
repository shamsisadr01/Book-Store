using Common.L1.Domain.Repository;
using Shop.L1.Domain.Comment_Aggregate;

namespace Shop.L1.Domain.Comment_Aggregate.Repositories
{
	public interface ICommentRepository : IBaseRepository<Comment>
	{
		Task DeleteAndSave(Comment comment);
	}
}

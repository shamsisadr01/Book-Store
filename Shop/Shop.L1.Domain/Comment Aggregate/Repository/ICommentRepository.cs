using Common.L1.Domain.Repository;

namespace Shop.L1.Domain.Comment_Aggregate.Repository
{
	public interface ICommentRepository : IBaseRepository<Comment>
	{
		Task DeleteAndSave(Comment comment);
	}
}

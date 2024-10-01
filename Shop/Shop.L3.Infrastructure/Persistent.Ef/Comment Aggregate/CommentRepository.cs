
using Shop.L1.Domain.Comment_Aggregate;
using Shop.L3.Infrastructure._Utilities;
using Shop.L1.Domain.Comment_Aggregate.Repository;

namespace Shop.L3.Infrastructure.Persistent.Ef.Comment_Aggregate
{
	public class CommentRepository : BaseRepository<Comment>, ICommentRepository
	{
		public CommentRepository(StoreContext context) : base(context)
		{
		}

		public async Task DeleteAndSave(Comment comment)
		{
			_storeContext.Remove(comment);
			await _storeContext.SaveChangesAsync();
		}
	}
}

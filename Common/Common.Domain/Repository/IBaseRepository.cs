using Common.L1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.L1.Domain.Repository
{
	public interface IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		TEntity? Get(long id);
		Task<TEntity?> GetAsync(long id);

		Task<TEntity?> GetTracking(long id);

		Task AddAsync(TEntity entity);

		Task Add(TEntity entity);

		Task AddRange(ICollection<TEntity> entities);

		void Update(TEntity entity);

		Task<int> Save();

		Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);

		bool Exists(Expression<Func<TEntity, bool>> expression);
	}
}

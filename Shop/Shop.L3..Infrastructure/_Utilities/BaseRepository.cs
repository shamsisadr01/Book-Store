using Common.L1.Domain;
using Common.L1.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L3.Infrastructure._Utilities
{
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		protected readonly StoreContext _storeContext;

		public BaseRepository(StoreContext storeContext)
		{
			_storeContext = storeContext;
		}

		public void Add(TEntity entity)
		{
			_storeContext.Set<TEntity>().Add(entity);
		}

		public async Task AddAsync(TEntity entity)
		{
			await _storeContext.Set<TEntity>().AddAsync(entity);
		}

		public async Task AddRange(ICollection<TEntity> entities)
		{
			await _storeContext.Set<TEntity>().AddRangeAsync(entities);
		}

		public bool Exists(Expression<Func<TEntity, bool>> expression)
		{
			return _storeContext.Set<TEntity>().Any(expression);
		}

		public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
		{
			return await _storeContext.Set<TEntity>().AnyAsync(expression);
		}

		public TEntity? Get(long id)
		{
			return _storeContext.Set<TEntity>().FirstOrDefault(t => t.Id.Equals(id)); 
		}

		public async Task<TEntity?> GetAsync(long id)
		{
			return await _storeContext.Set<TEntity>().FirstOrDefaultAsync(t => t.Id.Equals(id));
		}

		public async Task<TEntity?> GetTracking(long id)
		{
			return await _storeContext.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));
		}

		public async Task<int> Save()
		{
			return await _storeContext.SaveChangesAsync();
		}

		public void Update(TEntity entity)
		{
			_storeContext.Update(entity);
		}
	}
}

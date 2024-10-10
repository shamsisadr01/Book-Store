

using Common.L1.Domain.Repository;


namespace Shop.L1.Domain.Role_Aggregate.Repository
{
	public interface IRoleRepository : IBaseRepository<Role>
	{
        void Delete(Role role);
    }
}

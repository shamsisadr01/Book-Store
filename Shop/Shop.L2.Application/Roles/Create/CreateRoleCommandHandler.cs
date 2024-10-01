using Common.L2.Application;
using Shop.L1.Domain.Role_Aggregate.Repository;
using Shop.L1.Domain.Role_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Roles.Create
{
	public class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
	{
		private readonly IRoleRepository _repository;

		public CreateRoleCommandHandler(IRoleRepository repository)
		{
			_repository = repository;
		}

		public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
		{
			var permissions = new List<RolePermission>();
			request.Permissions.ForEach(f =>
			{
				permissions.Add(new RolePermission(f));
			});
			var role = new Role(request.Title, permissions);
			 _repository.Add(role);
			await _repository.Save();

			return OperationResult.Success();
		}
	}
}

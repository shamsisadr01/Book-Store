using Common.L2.Application;
using Shop.L1.Domain.Role_Aggregate.Repository;
using Shop.L1.Domain.Role_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Roles.Edit
{
	public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
	{
		private readonly IRoleRepository _repository;

		public EditRoleCommandHandler(IRoleRepository repository)
		{
			_repository = repository;
		}

		public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
		{
			var role = await _repository.GetTracking(request.Id);
			if (role == null)
				return OperationResult.NotFound();

			role.Edit(request.Title);

			var permissions = new List<RolePermission>();
			request.Permissions.ForEach(f =>
			{
				permissions.Add(new RolePermission(f));
			});
			role.SetPermissions(permissions);
			await _repository.Save();
			return OperationResult.Success();
		}
	}
}

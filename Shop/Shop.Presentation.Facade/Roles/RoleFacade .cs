using Common.L2.Application;
using MediatR;
using Shop.L2.Application.Roles.Create;
using Shop.L2.Application.Roles.Edit;
using Shop.L4.Query.Roles.DTOs;
using Shop.L4.Query.Roles.GetById;
using Shop.L4.Query.Roles.GetByList;

namespace Shop.L5.Presentation.Facade.Roles;

public class RoleFacade : IRoleFacade
{
	private readonly IMediator _mediator;
	public RoleFacade(IMediator mediator)
	{
		_mediator = mediator;
	}
	public async Task<OperationResult> CreateRole(CreateRoleCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<OperationResult> EditRole(EditRoleCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<RoleDto?> GetRoleById(long roleId)
	{
		return await _mediator.Send(new GetRoleByIdQuery(roleId));
	}
	public async Task<List<RoleDto>> GetRoles()
	{
		return await _mediator.Send(new GetRolesBytListQuery());
	}
}
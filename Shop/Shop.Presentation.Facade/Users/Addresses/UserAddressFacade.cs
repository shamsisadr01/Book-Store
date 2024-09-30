using Common.L2.Application;
using MediatR;
using Shop.L2.Application.Users.AddAddress;
using Shop.L2.Application.Users.EditAddress;

namespace Shop.L5.Presentation.Facade.Users.Addresses;

internal class UserAddressFacade : IUserAddressFacade
{
	private readonly IMediator _mediator;
	public UserAddressFacade(IMediator mediator)
	{
		_mediator = mediator;
	}
	public async Task<OperationResult> AddAddress(AddUserAddressCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<OperationResult> EditAddress(EditUserAddressCommand command)
	{
		return await _mediator.Send(command);
	}
}
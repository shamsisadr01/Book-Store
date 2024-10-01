using Common.L2.Application;
using MediatR;
using Shop.L2.Application.Users.AddAddress;
using Shop.L2.Application.Users.EditAddress;
using Shop.L2.Application.Users.RemoveAddress;
using Shop.L4.Query.Users.Addresses.DTOs;
using Shop.L4.Query.Users.Addresses.GetById;
using Shop.L4.Query.Users.Addresses.GetByList;

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

	public async Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command)
	{
		return await _mediator.Send(command);
	}

	public async Task<AddressDto?> GetById(long userAddressId)
	{
		return await _mediator.Send(new GetUserAddressByIdQuery(userAddressId));
	}
	public async Task<List<AddressDto>> GetList(long userId)
	{
		return await _mediator.Send(new GetUserAddressesListQuery(userId));
	}
}
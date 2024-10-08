using Common.L2.Application;
using Shop.L2.Application.Users.AddAddress;
using Shop.L2.Application.Users.EditAddress;
using Shop.L2.Application.Users.RemoveAddress;
using Shop.L2.Application.Users.SetActiveAddress;
using Shop.L4.Query.Users.Addresses.DTOs;

namespace Shop.L5.Presentation.Facade.Users.Addresses;

public interface IUserAddressFacade
{
	Task<OperationResult> AddAddress(AddUserAddressCommand command);
	Task<OperationResult> EditAddress(EditUserAddressCommand command);
    Task<OperationResult> SetAddressActive(SetActiveUserAddressCommand command);
    Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);

	Task<AddressDto?> GetById(long userAddressId);
	Task<List<AddressDto>> GetList(long userId);
  
}
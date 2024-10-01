using Common.L2.Application;
using Shop.L2.Application.Users.AddAddress;
using Shop.L2.Application.Users.EditAddress;

namespace Shop.L5.Presentation.Facade.Users.Addresses;

public interface IUserAddressFacade
{
	Task<OperationResult> AddAddress(AddUserAddressCommand command);
	Task<OperationResult> EditAddress(EditUserAddressCommand command);
}
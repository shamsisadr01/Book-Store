using Common.L2.Application;
using Shop.L2.Application.Users.Create;
using Shop.L2.Application.Users.Edit;
using Shop.L2.Application.Users.Register;
using Shop.L4.Query.Users.DTOs;

namespace Shop.L5.Presentation.Facade.Users;

public interface IUserFacade
{
	Task<OperationResult> RegisterUser(RegisterUserCommand command);
	Task<OperationResult> EditUser(EditUserCommand command);
	Task<OperationResult> CreateUser(CreateUserCommand command);
	Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
	Task<UserDto?> GetUserById(long userId);
	Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParamses);
}
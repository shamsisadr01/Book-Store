using Common.L2.Application;
using Common.L2.Application.SecurityUtil;
using MediatR;
using Shop.L1.Domain.User_Aggregate;
using Shop.L2.Application.Users.AddToken;
using Shop.L2.Application.Users.Create;
using Shop.L2.Application.Users.Edit;
using Shop.L2.Application.Users.Register;
using Shop.L2.Application.Users.RemoveToken;
using Shop.L4.Query.Users.DTOs;
using Shop.L4.Query.Users.GetByFilter;
using Shop.L4.Query.Users.GetById;
using Shop.L4.Query.Users.GetByPhoneNumber;
using Shop.L4.Query.Users.UserTokens;

namespace Shop.L5.Presentation.Facade.Users;

internal class UserFacade : IUserFacade
{
	private readonly IMediator _mediator;
	public UserFacade(IMediator mediator)
	{
		_mediator = mediator;
	}
	public async Task<OperationResult> CreateUser(CreateUserCommand command)
	{
		return await _mediator.Send(command);
	}

	public async Task<OperationResult> AddToken(AddUserTokenCommand command)
	{
		return await _mediator.Send(command);
	}

	public async Task<OperationResult> RemoveToken(RemoveUserTokenCommand command)
	{
		return await _mediator.Send(command);
	}

	public async Task<OperationResult> EditUser(EditUserCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<UserDto?> GetUserById(long userId)
	{
		return await _mediator.Send(new GetUserByIdQuery(userId));
	}

	public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
	{
		var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
		return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
	}

	public async Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
	{
		return await _mediator.Send(new GetUserByFilterQuery(filterParams));
	}
	public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
	{
		return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
	}
	public async Task<OperationResult> RegisterUser(RegisterUserCommand command)
	{
		return await _mediator.Send(command);
	}
}
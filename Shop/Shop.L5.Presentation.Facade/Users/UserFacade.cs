using Common.CacheHelper;
using Common.L2.Application;
using Common.L2.Application.SecurityUtil;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Shop.L1.Domain.User_Aggregate;
using Shop.L2.Application.Users.AddToken;
using Shop.L2.Application.Users.ChangePassword;
using Shop.L2.Application.Users.Create;
using Shop.L2.Application.Users.Edit;
using Shop.L2.Application.Users.Register;
using Shop.L2.Application.Users.RemoveToken;
using Shop.L4.Query.Users.DTOs;
using Shop.L4.Query.Users.GetByFilter;
using Shop.L4.Query.Users.GetById;
using Shop.L4.Query.Users.GetByPhoneNumber;
using Shop.L4.Query.Users.UserTokens;
using Shop.L4.Query.Users.UserTokens.GetByRefreshToken;
using Shop.L4.Query.Users.UserTokens.GetByToken;

namespace Shop.L5.Presentation.Facade.Users;

internal class UserFacade : IUserFacade
{
	private readonly IMediator _mediator;
	private IDistributedCache _distributedCache;
	public UserFacade(IMediator mediator, IDistributedCache distributedCache)
    {
        _mediator = mediator;
        _distributedCache = distributedCache;
    }
	public async Task<OperationResult> CreateUser(CreateUserCommand command)
	{
		return await _mediator.Send(command);
	}

    public async Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command)
    {
        await _distributedCache.RefreshAsync(CacheKeys.User(command.UserId));
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AddToken(AddUserTokenCommand command)
	{
		return await _mediator.Send(command);
	}

	public async Task<OperationResult> RemoveToken(RemoveUserTokenCommand command)
	{
        var result = await _mediator.Send(command);
		if(result.Status != OperationResultStatus.Success)
			return OperationResult.Error();

        await _distributedCache.RefreshAsync(CacheKeys.UserToken(result.Data));
		return OperationResult.Success();
    }

	public async Task<OperationResult> EditUser(EditUserCommand command)
    {
		var result = await _mediator.Send(command);
        if (result.Status == OperationResultStatus.Success)
        {
            await _distributedCache.RefreshAsync(CacheKeys.User(command.UserId));
        }

        return result;
    }
	public async Task<UserDto?> GetUserById(long userId)
    {
        return await _distributedCache.GetOrSet(CacheKeys.User(userId), () =>
        {
            return _mediator.Send(new GetUserByIdQuery(userId));
        });
    }

	public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
	{
		var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
		return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
	}

	public async Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken)
	{
		var hashjwtToken = Sha256Hasher.Hash(jwtToken);
        return await _distributedCache.GetOrSet(CacheKeys.UserToken(hashjwtToken), () =>
        {
            return _mediator.Send(new GetUserTokenByJwtTokenQuery(hashjwtToken));
        });
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
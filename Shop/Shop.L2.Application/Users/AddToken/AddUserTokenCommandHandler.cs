using Common.L2.Application;
using Shop.L1.Domain.User_Aggregate.Repository;

namespace Shop.L2.Application.Users.AddToken;

public class AddUserTokenCommandHandler : IBaseCommandHandler<AddUserTokenCommand>
{
	private IUserRepository _userRepository;

	public AddUserTokenCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<OperationResult> Handle(AddUserTokenCommand request, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetTracking(request.UserId);
		if (user == null) 
			return OperationResult.NotFound();
		user.AddToken(request.HashJwToken, request.HashRefreshToken, 
			request.TokenExpireDate, request.RefreshTokenExpireDate,request.Device);

		await _userRepository.Save();
		return OperationResult.Success();
	}
}
using Common.L2.Application;
using Shop.L1.Domain.User_Aggregate.Repository;

namespace Shop.L2.Application.Users.RemoveToken;

internal class RemoveUserTokenCommandHandler : IBaseCommandHandler<RemoveUserTokenCommand>
{
	private readonly IUserRepository _userRepository;

	public RemoveUserTokenCommandHandler(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<OperationResult> Handle(RemoveUserTokenCommand request, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetTracking(request.UserId);
		if (user == null)
			return OperationResult.NotFound();

		 user.RemoveToken(request.TokenId);
		await _userRepository.Save();
		return OperationResult.Success();
	}
}
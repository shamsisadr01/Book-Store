using Common.L2.Application;
using Shop.L1.Domain.User_Aggregate.Repository;

namespace Shop.L2.Application.Users.SetActiveAddress;

public record SetActiveUserAddressCommand(long userId,long addressId) : IBaseCommand;

public class SetActiveUserAddressCommandHandler : IBaseCommandHandler<SetActiveUserAddressCommand>
{
    private readonly IUserRepository _userRepository;

    public SetActiveUserAddressCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(SetActiveUserAddressCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.userId);
        if (user == null)
            return OperationResult.NotFound();

        user.SetActiveAddress(request.addressId);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}
using Common.L2.Application;
using Common.L2.Application.SecurityUtil;
using Shop.L1.Domain.User_Aggregate.Repository;

namespace Shop.L2.Application.Users.ChangePassword;

public class ChangeUserPasswordCommandHandler : IBaseCommandHandler<ChangeUserPasswordCommand>
{
    private readonly IUserRepository _userRepository;

    public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);
        if(user  == null) 
            return OperationResult.Error("کاربر یافت نشد.");
        var currentPasswordHash = Sha256Hasher.Hash(request.CurrentPassword);
        if(currentPasswordHash != user.Password)
            return OperationResult.Error("کلمه عبور فعلی نامعتبر است.");

        var newPasswordHash = Sha256Hasher.Hash(request.Password);
        user.ChangePassword(newPasswordHash);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}
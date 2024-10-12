using Common.L2.Application;

namespace Shop.L2.Application.Users.RemoveToken;

public record RemoveUserTokenCommand(long UserId, long TokenId) : IBaseCommand<string>;
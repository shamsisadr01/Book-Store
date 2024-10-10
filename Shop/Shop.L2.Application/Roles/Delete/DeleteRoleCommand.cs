using Common.L2.Application;
using Shop.L2.Application._Utilities;

namespace Shop.L2.Application.Roles.Delete;

public record DeleteRoleCommand(long Id) : IBaseCommand;
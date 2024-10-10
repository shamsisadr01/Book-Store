using Common.L2.Application;
using Shop.L1.Domain.Role_Aggregate.Repository;

namespace Shop.L2.Application.Roles.Delete;

internal class DeleteRoleCommandHandler : IBaseCommandHandler<DeleteRoleCommand>
{
    private  readonly IRoleRepository _repository;

    public DeleteRoleCommandHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetTracking(request.Id);
        if (banner == null)
            return OperationResult.NotFound();

        _repository.Delete(banner);
        await _repository.Save();
        return OperationResult.Success();
    }
}
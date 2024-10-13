using Common.L2.Application;
using Shop.L1.Domain.Comment_Aggregate.Repository;

namespace Shop.L2.Application.Comments.Delete;

public class DeleteCommentCommandHandler : IBaseCommandHandler<DeleteCommentCommand>
{
    private readonly ICommentRepository _repository;

    public DeleteCommentCommandHandler(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _repository.GetTracking(request.CommentId);
        if (comment == null || comment.UserId != request.UserId)
            return OperationResult.NotFound();

        await _repository.DeleteAndSave(comment);
        return OperationResult.Success();
    }
}
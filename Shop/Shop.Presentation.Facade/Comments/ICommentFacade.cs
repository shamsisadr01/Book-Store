using Common.L2.Application;
using Shop.L2.Application.Comments.ChangeStatus;
using Shop.L2.Application.Comments.Create;
using Shop.L2.Application.Comments.Edit;
using Shop.L4.Query.Comments.DTOs;

namespace Shop.L5.Presentation.Facade.Comments;

public interface ICommentFacade
{
	Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command);
	Task<OperationResult> CreateComment(CreateCommentCommand command);
	Task<OperationResult> EditComment(EditCommentCommand command);
	//Task<OperationResult> DeleteComment(DeleteCommentCommand command);


	Task<CommentDto?> GetCommentById(long id);
	Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams);
}
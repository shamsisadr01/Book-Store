using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.L2.Application;
using MediatR;
using Shop.L2.Application.Comments.ChangeStatus;
using Shop.L2.Application.Comments.Create;
using Shop.L2.Application.Comments.Delete;
using Shop.L2.Application.Comments.Edit;
using Shop.L4.Query.Comments.DTOs;
using Shop.L4.Query.Comments.GetByFilter;
using Shop.L4.Query.Comments.GetById;

namespace Shop.L5.Presentation.Facade.Comments
{
	internal class CommentFacade : ICommentFacade
	{
		private readonly IMediator _mediator;

		public CommentFacade(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command)
		{
			return await _mediator.Send(command);
		}

		public async Task<OperationResult> CreateComment(CreateCommentCommand command)
		{
			return await _mediator.Send(command);

		}

		public async Task<OperationResult> EditComment(EditCommentCommand command)
		{
			return await _mediator.Send(command);
		}

		public async Task<OperationResult> DeleteComment(DeleteCommentCommand command)
		{
			return await _mediator.Send(command);
		}

		public async Task<CommentDto?> GetCommentById(long id)
		{
			return await _mediator.Send(new GetCommentByIdQuery(id));
		}

		public async Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams)
		{
			return await _mediator.Send(new GetCommentByFilterQuery(filterParams));
		}
	}
}

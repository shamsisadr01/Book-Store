﻿using Common.AspNetCore;
using Common.L2.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.L1.Domain.Role_Aggregate.Enums;
using Shop.L2.Application.Comments.ChangeStatus;
using Shop.L2.Application.Comments.Create;
using Shop.L2.Application.Comments.Edit;
using Shop.L4.Query.Comments.DTOs;
using Shop.L5.Presentation.Facade.Comments;

namespace Shop.Api.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentFacade _commentFacade;

        public CommentController(ICommentFacade commentFacade)
        {
	        _commentFacade = commentFacade;
        }

        [HttpGet,PermissionChecker(Permission.Comment_Management)]
        public async Task<ApiResult<CommentFilterResult>> GetCommentByFilter(
	        [FromQuery] CommentFilterParams filterParams)
        {
	        var result = await _commentFacade.GetCommentsByFilter(filterParams);
	        return QueryResult(result);
        }

        [HttpGet("{commentId}"), PermissionChecker(Permission.Comment_Management)]
        public async Task<ApiResult<CommentDto?>> GetCommentById(long commentId)
        {
	        var result = await _commentFacade.GetCommentById(commentId);
	        return QueryResult(result);
        }

        [HttpPost,Authorize]
        public async Task<ApiResult> CreateComment(CreateCommentCommand command)
        {
	        var result = await _commentFacade.CreateComment(command);
	        return CommandResult(result);
        }
        [HttpPut,Authorize]
        public async Task<ApiResult> EditComment(EditCommentCommand command)
        {
	        var result = await _commentFacade.EditComment(command);
	        return CommandResult(result);
        }

        [HttpPut("changeStatus"), PermissionChecker(Permission.Comment_Management)]
        public async Task<ApiResult> ChangeCommentStatus(ChangeCommentStatusCommand command)
        {
	        var result = await _commentFacade.ChangeStatus(command);
	        return CommandResult(result);
        }
	}
}

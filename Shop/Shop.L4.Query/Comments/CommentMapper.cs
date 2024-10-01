using Shop.L1.Domain.Comment_Aggregate;
using Shop.L4.Query.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Comments
{
	internal static class CommentMapper
	{
		public static CommentDto? Map(this Comment? comment)
		{
			if (comment == null)
				return null;

			return new CommentDto()
			{
				Id = comment.Id,
				CreationDate = comment.CreationDate,
				Status = comment.Status,
				UserId = comment.UserId,
				ProductId = comment.ProductId,
				Text = comment.Text,

			};
		}
		public static CommentDto MapFilterComment(this Comment comment)
		{
			if (comment == null)
				return null;
			return new CommentDto()
			{
				Id = comment.Id,
				CreationDate = comment.CreationDate,
				Status = comment.Status,
				UserId = comment.UserId,
				ProductId = comment.ProductId,
				Text = comment.Text,

			};
		}
	}
}

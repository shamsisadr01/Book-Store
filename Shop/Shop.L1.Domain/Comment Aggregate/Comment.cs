﻿using Common.L1.Domain;
using Common.L1.Domain.Exceptions;
using Shop.L1.Domain.Comment_Aggregate.Enums;

namespace Shop.L1.Domain.Comment_Aggregate
{
	public class Comment : AggregateRoot
	{
		public long UserId { get; private set; }
		public long ProductId { get; private set; }
		public string Text { get; private set; }
		public CommentStatus Status { get; private set; }
		public DateTime UpdateDate { get; private set; }

		public Comment(long userId, long productId, string text)
		{
			NullOrEmptyDomainDataException.CheckString(text, nameof(text));

			UserId = userId;
			ProductId = productId;
			Text = text;
			Status = CommentStatus.Pending;
		}

		public void Edit(string text)
		{
			NullOrEmptyDomainDataException.CheckString(text, nameof(text));

			Text = text;
			UpdateDate = DateTime.Now;
		}

		public void ChangeStatus(CommentStatus status)
		{
			Status = status;
			UpdateDate = DateTime.Now;
		}
	}
}

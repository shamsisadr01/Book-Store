using Common.L2.Application;
using Microsoft.AspNetCore.Http;
using Shop.L1.Domain.User_Aggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Users.Edit
{
	public class EditUserCommand : IBaseCommand
	{
		public long UserId { get; set; }
		public IFormFile? Avatar { get; private set; }
		public string Name { get; private set; }
		public string Family { get; private set; }
		public string PhoneNumber { get; private set; }
		public string Email { get; private set; }
		public Gender Gender { get; private set; }
	}
}

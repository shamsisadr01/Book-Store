using Shop.L1.Domain.User_Aggregate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Users
{
	public class UserDomainService : IUserDomainService
	{
		public bool IsEmailExist(string email)
		{
			throw new NotImplementedException();
		}

		public bool PhoneNumberIsExist(string phoneNumber)
		{
			throw new NotImplementedException();
		}
	}
}

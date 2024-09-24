﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shop.Domain.User_Aggregate.Services
{
	public interface IDomainUserService
	{
		bool IsEmailExist(string email);

		bool PhoneNumberIsExist(string phoneNumber);
	}
}

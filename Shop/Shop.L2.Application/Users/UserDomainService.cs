using Shop.L1.Domain.User_Aggregate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.L1.Domain.Product_Aggregate.Repository;
using Shop.L1.Domain.User_Aggregate.Repository;

namespace Shop.L2.Application.Users
{
	public class UserDomainService : IUserDomainService
	{
		private readonly IUserRepository _repository;

		public UserDomainService(IUserRepository repository)
		{
			_repository = repository;
		}

		public bool IsEmailExist(string email)
		{
			return _repository.Exists(e => e.Email == email);
		}

		public bool PhoneNumberIsExist(string phoneNumber)
		{
			return _repository.Exists(e => e.PhoneNumber == phoneNumber);
		}
	}
}

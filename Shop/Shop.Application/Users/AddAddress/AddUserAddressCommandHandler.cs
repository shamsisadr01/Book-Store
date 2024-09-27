using Common.L2.Application;
using Shop.L1.Domain.User_Aggregate.Repository;
using Shop.L1.Domain.User_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Users.AddAddress
{
	public class AddUserAddressCommandHandler : IBaseCommandHandler<AddUserAddressCommand>
	{
		private readonly IUserRepository _repository;

		public AddUserAddressCommandHandler(IUserRepository repository)
		{
			_repository = repository;
		}

		public async Task<OperationResult> Handle(AddUserAddressCommand request, CancellationToken cancellationToken)
		{
			var user = await _repository.GetTracking(request.UserId);
			if (user == null)
				return OperationResult.NotFound();

			var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress,
				request.PhoneNumber, request.Name, request.Family, request.NationalCode);
			user.AddAddress(address);
			await _repository.Save();
			return OperationResult.Success();
		}
	}
}

using Common.L2.Application;
using Shop.L1.Domain.User_Aggregate.Repository;
using Shop.L1.Domain.User_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Users.EditAddress
{
	internal class EditUserAddressCommandHandler : IBaseCommandHandler<EditUserAddressCommand>
	{
		private readonly IUserRepository _repository;

		public EditUserAddressCommandHandler(IUserRepository repository)
		{
			_repository = repository;
		}

		public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
		{
			var user = await _repository.GetTracking(request.UserId);
			if (user == null)
				return OperationResult.NotFound();

			var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress,
				request.PhoneNumber, request.Name, request.Family, request.NationalCode);

			user.EditAddress(address, request.Id);
			await _repository.Save();

			return OperationResult.Success();
		}
	}
}

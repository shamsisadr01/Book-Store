using Common.L2.Application;
using Shop.L1.Domain.User_Aggregate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Users.RemoveAddress
{
	public class DeleteUserAddressCommandHandler : IBaseCommandHandler<DeleteUserAddressCommand>
	{
		private readonly IUserRepository _repository;

		public DeleteUserAddressCommandHandler(IUserRepository repository)
		{
			_repository = repository;
		}

		public async Task<OperationResult> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
		{
			var user = await _repository.GetTracking(request.UserId);
			if (user == null)
				return OperationResult.NotFound();

			user.RemoveAddress(request.AddressId);

			await _repository.Save();
			return OperationResult.Success();
		}
	}
}

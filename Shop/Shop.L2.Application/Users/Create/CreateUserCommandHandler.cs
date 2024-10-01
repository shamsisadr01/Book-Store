using _1.Shop.Domain.User_Aggregate;
using Common.L2.Application;
using Common.L2.Application.SecurityUtil;
using Shop.L1.Domain.User_Aggregate.Repository;
using Shop.L1.Domain.User_Aggregate.Services;


namespace Shop.L2.Application.Users.Create
{
	public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
	{
		private readonly IUserRepository _repository;
		private readonly IUserDomainService _userDomainService;
		public CreateUserCommandHandler(IUserRepository repository, IUserDomainService userDomainService)
		{
			_repository = repository;
			_userDomainService = userDomainService;
		}

		public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var password = Sha256Hasher.Hash(request.Password);
			var user = new User(request.Name, request.Family, request.PhoneNumber
				, request.Email, password, request.Gender, _userDomainService);

			_repository.Add(user);
			await _repository.Save();
			return OperationResult.Success();
		}
	}
}

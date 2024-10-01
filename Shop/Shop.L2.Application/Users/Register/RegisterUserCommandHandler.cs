
using Common.L2.Application;
using Common.L2.Application.SecurityUtil;
using Shop.L1.Domain.User_Aggregate;
using Shop.L1.Domain.User_Aggregate.Repository;
using Shop.L1.Domain.User_Aggregate.Services;


namespace Shop.L2.Application.Users.Register
{
	public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
	{
		private readonly IUserRepository _repository;
		private readonly IUserDomainService _domainService;

		public RegisterUserCommandHandler(IUserRepository repository, IUserDomainService domainService)
		{
			_repository = repository;
			_domainService = domainService;
		}

		public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		{
			var user = User.RegisterUser(request.PhoneNumber.Value, Sha256Hasher.Hash(request.Password), _domainService);

			_repository.Add(user);
			await _repository.Save();
			return OperationResult.Success();
		}
	}
}



namespace Shop.L1.Domain.User_Aggregate.Services
{
	public interface IUserDomainService
	{
		bool IsEmailExist(string email);

		bool PhoneNumberIsExist(string phoneNumber);
	}
}

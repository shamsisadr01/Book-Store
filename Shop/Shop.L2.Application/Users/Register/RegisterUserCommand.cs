using Common.L1.Domain.ValueObjects;
using Common.L2.Application;

namespace Shop.L2.Application.Users.Register
{
	public class RegisterUserCommand : IBaseCommand
	{
		public RegisterUserCommand(PhoneNumber phoneNumber, string password)
		{
			PhoneNumber = phoneNumber;
			Password = password;
		}
		public PhoneNumber PhoneNumber { get; private set; }
		public string Password { get; private set; }
	}
}

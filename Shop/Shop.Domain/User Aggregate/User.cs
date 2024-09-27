

using Common.L1.Domain;
using Common.L1.Domain.Exceptions;
using Shop.L1.Domain.User_Aggregate;
using Shop.L1.Domain.User_Aggregate.Enums;
using Shop.L1.Domain.User_Aggregate.Services;

namespace _1.Shop.Domain.User_Aggregate
{
	public class User : AggregateRoot
	{
		public User(string name, string family, string phoneNumber, string email,
			string password, Gender gender, IUserDomainService domainUserService)
		{
			Guard(phoneNumber, email, domainUserService);
			Name = name;
			Family = family;
			PhoneNumber = phoneNumber;
			Email = email;
			Password = password;
			Gender = gender;
			AvatarName = "avatar.png";
		}

		public string Name { get; private set; }
		public string Family {  get; private set; }
		public string PhoneNumber { get; private set; }
		public string Email {  get; private set; }
		public string Password { get; private set; }
		public string AvatarName {  get; private set; }
		public Gender Gender { get; private set; }

		public List<UserRole> Roles { get; private set; }
		public List<UserAddress> Addresses { get; private set; }
		public List<Wallet> Wallets { get; private set; }


		public void Edit(string name, string family, string phoneNumber, string email, 
			Gender gender, IUserDomainService domainUserService)
		{
			Guard(phoneNumber,email,domainUserService);
			Name = name;
			Family = family;
			PhoneNumber = phoneNumber;
			Email = email;
		}

		public static User RegisterUser(string phoneNumber,string password, IUserDomainService domainUserService)
		{
			return new User("", "", phoneNumber, "", password, Gender.None, domainUserService);
		}

		public void AddAddress(UserAddress address)
		{
			address.UserId = Id;
			Addresses.Add(address);
		}

		public void EditAddress(UserAddress address, long addressId)
		{
			var oldAddress = Addresses.FirstOrDefault(a => a.Id == addressId);
			if (oldAddress != null)
				throw new NullOrEmptyDomainDataException("آدرس پیدا نشد.");

			oldAddress.Edit(address.Shire, address.City, address.PostalCode, address.PostalAddress, address.PhoneNumber,
			address.Name, address.Family, address.NationalCode);
		}

		public void RemoveAddress(long addressId)
		{
			var oldAddress = Addresses.FirstOrDefault(address => address.Id == addressId);
			if (oldAddress != null)
				throw new NullOrEmptyDomainDataException("آدرس پیدا نشد.");

			Addresses.Remove(oldAddress);
		}

		public void ChargeWallet(Wallet wallet)
		{
			wallet.UserId = Id;
			Wallets.Add(wallet);
		}

		public void SetRoles(List<UserRole> roles)
		{
			roles.ForEach(f => f.UserId = Id);
			Roles.Clear();
			Roles.AddRange(roles);
		}
		public void SetAvatar(string avatar)
		{
			if(string.IsNullOrWhiteSpace(avatar))
				avatar = "avatar.png";
			AvatarName = avatar;
		}

		public void Guard(string phoneNumber, string email, IUserDomainService domainUserService)
		{
			NullOrEmptyDomainDataException.CheckString(phoneNumber,nameof(phoneNumber));
			NullOrEmptyDomainDataException.CheckString(email,nameof(email));

			if (phoneNumber.Length != 11)
				throw new InvalidDomainDataException("شماره تلفن نامعتبر است.");

			if(email.IsValidEmail())
				throw new InvalidDomainDataException("ایمیل نا معتبر است.");

			if(phoneNumber != PhoneNumber)
				if(domainUserService.PhoneNumberIsExist(phoneNumber))
					throw new InvalidDomainDataException("شماره تلفن تکراری است.");

			if (email != Email)
				if (domainUserService.IsEmailExist(email))
					throw new InvalidDomainDataException("ایمیل تکراری است.");
		}
    }

}

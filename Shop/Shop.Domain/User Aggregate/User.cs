using _1.Shop.Domain.User_Aggregate.Enums;
using _1.Shop.Domain.User_Aggregate.Services;
using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shop.Domain.User_Aggregate
{
	public class User : AggregateRoot
	{
		public User(string name, string family, string phoneNumber, string email,
			string password, Gender gender, IDomainUserService domainUserService)
		{
			Guard(phoneNumber, email, domainUserService);
			Name = name;
			Family = family;
			PhoneNumber = phoneNumber;
			Email = email;
			Password = password;
			Gender = gender;
		}

		public string Name { get; private set; }
		public string Family {  get; private set; }
		public string PhoneNumber { get; private set; }
		public string Email {  get; private set; }
		public string Password { get; private set; }
		public Gender Gender { get; private set; }

		public List<UserRole> Roles { get; private set; }
		public List<UserAddress> Addresses { get; private set; }
		public List<Wallet> Wallets { get; private set; }


		public void Edit(string name, string family, string phoneNumber, string email, 
			Gender gender, IDomainUserService domainUserService)
		{
			Guard(phoneNumber,email,domainUserService);
			Name = name;
			Family = family;
			PhoneNumber = phoneNumber;
			Email = email;
		}

		public static User RegisterUser(string email,string phoneNumber,string password, IDomainUserService domainUserService)
		{
			return new User("", "", phoneNumber, email, password, Gender.None, domainUserService);
		}

		public void AddAddress(UserAddress address)
		{
			address.UserId = Id;
			Addresses.Add(address);
		}

		public void EditAddress(UserAddress address)
		{
			var oldAddress = Addresses.FirstOrDefault(a => a.Id == address.Id);
			if (oldAddress != null)
				throw new NullOrEmptyDomainDataException("آدرس پیدا نشد.");

			Addresses.Remove(oldAddress);
			Addresses.Add(address);
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

		public void Guard(string phoneNumber, string email, IDomainUserService domainUserService)
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

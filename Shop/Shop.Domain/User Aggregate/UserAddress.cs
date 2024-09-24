using Common.Domain;
using Common.Domain.Exceptions;

namespace _1.Shop.Domain.User_Aggregate
{
	public class UserAddress : BaseEntity
	{
		public UserAddress(string shire, string city, string postalCode, string postalAddress,
			string phoneNumber, string name, string family, string nationalCode)
		{
			Guard(shire, city, postalCode, postalAddress,
		phoneNumber, name, family, nationalCode);
			Shire = shire;
			City = city;
			PostalCode = postalCode;
			PostalAddress = postalAddress;
			PhoneNumber = phoneNumber;
			Name = name;
			Family = family;
			NationalCode = nationalCode;
			ActiveAddress = false;
		}

		public long UserId { get; internal set; }

		public string Shire { get; private set; }
		public string City { get; private set; }
		public string PostalCode { get; private set; }
		public string PostalAddress { get; private set; }
		public string PhoneNumber { get; private set; }
		public string Name { get; private set; }
		public string Family { get; private set; }
		public string NationalCode { get; private set; }
		public bool ActiveAddress { get; private set; }


		public void Edit(string shire, string city, string postalCode, string postalAddress,
			string phoneNumber, string name, string family, string nationalCode)
		{
			Guard(shire, city, postalCode, postalAddress,
		phoneNumber, name, family, nationalCode);
			Shire = shire;
			City = city;
			PostalCode = postalCode;
			PostalAddress = postalAddress;
			PhoneNumber = phoneNumber;
			Name = name;
			Family = family;
			NationalCode = nationalCode;
		}

		public void SetActive()
		{
			ActiveAddress = true;
		}

		public void SetDeActive()
		{
			ActiveAddress = false;
		}

		public void Guard(string shire, string city, string postalCode, string postalAddress,
			string phoneNumber, string name, string family, string nationalCode)
		{
			if (phoneNumber == null)
				throw new NullOrEmptyDomainDataException();

			NullOrEmptyDomainDataException.CheckedString(shire, nameof(shire));
			NullOrEmptyDomainDataException.CheckedString(city, nameof(city));
			NullOrEmptyDomainDataException.CheckedString(postalCode, nameof(postalCode));
			NullOrEmptyDomainDataException.CheckedString(postalAddress, nameof(postalAddress));
			NullOrEmptyDomainDataException.CheckedString(name, nameof(name));
			NullOrEmptyDomainDataException.CheckedString(family, nameof(family));
			NullOrEmptyDomainDataException.CheckedString(nationalCode, nameof(nationalCode));

			if (IranianNationalIdChecker.IsValid(nationalCode) == false)
				throw new InvalidDomainDataException("کدملی نامعتبر است");
		}
	}

}

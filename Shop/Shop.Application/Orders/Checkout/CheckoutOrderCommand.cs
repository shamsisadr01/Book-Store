using Common.L2.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Orders.Checkout
{
	public class CheckoutOrderCommand : IBaseCommand
	{
		public CheckoutOrderCommand(long userID, string shire, string city, 
			string postalCode, string postalAddress, string phoneNumber, 
			string name, string family, string nationalCode,long shippingMethodId)
		{
			UserID = userID;
			Shire = shire;
			City = city;
			PostalCode = postalCode;
			PostalAddress = postalAddress;
			PhoneNumber = phoneNumber;
			Name = name;
			Family = family;
			NationalCode = nationalCode;
			ShippingMethodId = shippingMethodId;
		}

		public long UserID { get; private set; }
		public string Shire { get; private set; }
		public string City { get; private set; }
		public string PostalCode { get; private set; }
		public string PostalAddress { get; private set; }
		public string PhoneNumber { get; private set; }
		public string Name { get; private set; }
		public string Family { get; private set; }
		public string NationalCode { get; private set; }
		public long ShippingMethodId {  get; private set; }
	}
}

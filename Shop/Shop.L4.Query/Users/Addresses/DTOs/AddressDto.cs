﻿
using Common.L4.Query;

namespace Shop.L4.Query.Users.Addresses.DTOs;

public class AddressDto : BaseDto
{

	public long UserId { get;  set; }

	public string Shire { get;  set; }
	public string City { get;  set; }
	public string PostalCode { get;  set; }
	public string PostalAddress { get;  set; }
	public string PhoneNumber { get;  set; }
	public string Name { get;  set; }
	public string Family { get;  set; }
	public string NationalCode { get;  set; }
	public bool ActiveAddress { get;  set; }
}
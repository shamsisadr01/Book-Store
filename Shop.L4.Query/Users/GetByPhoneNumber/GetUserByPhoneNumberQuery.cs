using System;

using Common.L4.Query;
using Shop.L4.Query.Users.DTOs;

namespace Shop.L4.Query.Users.GetByPhoneNumber
{
	public record GetUserByPhoneNumberQuery(string phoneNumber) : IQuery<UserDto?>;
}

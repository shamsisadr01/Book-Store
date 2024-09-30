using Common.L4.Query;
using Common.L4.Query.Filter;
using Shop.L1.Domain.User_Aggregate;
using Shop.L1.Domain.User_Aggregate.Enums;

namespace Shop.L4.Query.Users.DTOs
{
	public class UserDto : BaseDto
	{
		public string Name { get;  set; }
		public string Family { get;  set; }
		public string PhoneNumber { get;  set; }
		public string Email { get;  set; }
		public string Password { get;  set; }
		public string AvatarName { get;  set; }
		public Gender Gender { get;  set; }
		public List<UserRoleDto> Roles { get;  set; }
	}

	public class UserRoleDto
	{
		public long roleId { get; set; }
		public string RoleTitle { get; set; }
	}

	public class UserFilterData : BaseDto
	{
		public string Name { get; set; }
		public string Family { get; set; }
		public string PhoneNumber { get; set; }
		public string? Email { get; set; }
		public string Password { get; set; }
		public string AvatarName { get; set; }

		public Gender Gender { get; set; }
	}

	public class UserFilterParams : BaseFilterParam
	{
		public string? PhoneNumber { get; set; }
		public string? Email { get; set; }
		public long? Id { get; set; }
	}

	public class UserFilterResult : BaseFilter<UserFilterData, UserFilterParams>
	{

	}
}
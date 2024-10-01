
using Microsoft.EntityFrameworkCore;
using Shop.L1.Domain.User_Aggregate;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Users.DTOs;

namespace Shop.L4.Query.Users
{
	public static class UserMapper
	{
		public static UserDto Map(this User user)
		{
			return new UserDto()
			{
				Id = user.Id,
				Name = user.Name,
				CreationDate = user.CreationDate,
				AvatarName = user.AvatarName,
				Email = user.Email,
				Family = user.Family,
				Gender = user.Gender,
				Password = user.Password,
				PhoneNumber = user.PhoneNumber,
				Roles = user.Roles.Select(r=>new UserRoleDto()
				{
					roleId = r.RoleId,
					RoleTitle ="",
				}).ToList()
			};
		}

		public static async Task<UserDto> SetUserRoleTitles(this UserDto userDto,StoreContext context)
		{
			var roleIds = userDto.Roles.Select(r => r.roleId);
			var result = await context.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();
			var roles = new List<UserRoleDto>();
			foreach (var role in result)
			{
				roles.Add(new UserRoleDto()
				{
					roleId = role.Id,
					RoleTitle = role.Title
				});
			}

			userDto.Roles = roles;
			return userDto;
		}

		public static UserFilterData MapFilterData(this User user)
		{
			return new UserFilterData()
			{
				Id = user.Id,
				Name = user.Name,
				CreationDate = user.CreationDate,
				AvatarName = user.AvatarName,
				Email = user.Email,
				Family = user.Family,
				Gender = user.Gender,
				Password = user.Password,
				PhoneNumber = user.PhoneNumber,
			};
		}
	}
}

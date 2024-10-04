using AutoMapper;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Users;
using Shop.L1.Domain.User_Aggregate;
using Shop.L2.Application.Users.AddAddress;
using Shop.L2.Application.Users.EditAddress;
using Shop.L2.Application.Users.RemoveAddress;
using Shop.L4.Query.Users.Addresses.DTOs;
using Shop.L5.Presentation.Facade.Users.Addresses;

namespace Shop.Api.Controllers
{
	[Authorize]
	public class UserAddressController : ApiController
	{
		private readonly IUserAddressFacade _userAddress;
		private readonly IMapper _mapper;
		public UserAddressController(IUserAddressFacade userAddress, IMapper mapper)
		{
			_userAddress = userAddress;
			_mapper = mapper;
		}

		[HttpGet("{userId}")]
		public async Task<ApiResult<List<AddressDto>>> GetByList()
		{
			var result = await _userAddress.GetList(User.GetUserId());
			return QueryResult(result);
		}

		[HttpGet("{addressId}")]
		public async Task<ApiResult<AddressDto?>> GetById(long addressId)
		{
			var result = await _userAddress.GetById(addressId);
			return QueryResult(result);
		}

		[HttpPost]
		public async Task<ApiResult> AddAddress(AddUserAddressViewModel viewModel)
		{
			var command = _mapper.Map<AddUserAddressCommand>(viewModel);
			command.UserId = User.GetUserId();
			var result = await _userAddress.AddAddress(command);
			return CommandResult(result);
		}

		[HttpDelete("{addressId}")]
		public async Task<ApiResult> Delete(long addressId)
		{
			var userId = 1;
			var result = await _userAddress.DeleteAddress(new DeleteUserAddressCommand(userId, addressId));
			return CommandResult(result);
		}

		[HttpPut]
		public async Task<ApiResult> EditAddress(EditUserAddressViewModel viewModel)
		{
			var command = _mapper.Map<EditUserAddressCommand>(viewModel);
			command.UserId = User.GetUserId();
			var result = await _userAddress.EditAddress(command);
			return CommandResult(result);
		}
	}
}

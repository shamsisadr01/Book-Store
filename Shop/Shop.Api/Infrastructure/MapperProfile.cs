using AutoMapper;
using Shop.Api.ViewModels.Users;
using Shop.L2.Application.Users.AddAddress;
using Shop.L2.Application.Users.ChangePassword;
using Shop.L2.Application.Users.Edit;
using Shop.L2.Application.Users.EditAddress;

namespace Shop.Api.Infrastructure;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<AddUserAddressCommand, AddUserAddressViewModel>().ReverseMap();
		CreateMap<EditUserAddressCommand, EditUserAddressViewModel>().ReverseMap();
		CreateMap<ChangeUserPasswordCommand, ChangePasswordViewModel>().ReverseMap();
		CreateMap<EditUserCommand, EditUserViewModel>().ReverseMap();
	}
}
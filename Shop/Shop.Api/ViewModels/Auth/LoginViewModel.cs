using System.ComponentModel.DataAnnotations;
using Common.L2.Application.Validation;

namespace Shop.Api.ViewModels.Auth
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "شماره تلفن را وارد کنید.")]
		[MaxLength(11,ErrorMessage = ValidationMessages.InvalidPhoneNumber),
		 MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "کلمه عبور را وارد کنید.")]
		public string Password { get; set; }
	}
}

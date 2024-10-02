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

	public class RegisterViewModel
	{
		[Required(ErrorMessage = "شماره تلفن را وارد کنید.")]
		[MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber),
		 MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "کلمه عبور را وارد کنید."),
		MinLength(6,ErrorMessage = "کلمه عبور باید بیشتر از 6 کاراکتر باشد.")]
		public string Password { get; set; }

		[Required(ErrorMessage = "تکرار کلمه عبور را وارد کنید."),
		 MinLength(6, ErrorMessage = "تکرار کلمه عبور باید بیشتر از 6 کاراکتر باشد."),
		Compare(nameof(Password),ErrorMessage = "رمز با تایید آن برابر نیست.")]
		public string ConfirmPassword { get; set; }
	}
}

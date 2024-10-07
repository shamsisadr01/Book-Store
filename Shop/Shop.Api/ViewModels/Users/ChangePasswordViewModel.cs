using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Users;

public class ChangePasswordViewModel
{   
    [Display(Name = "کلمه عبور فعلی")]
    [Required(ErrorMessage = "{0}  واراد نشده است.")]
    public string CurrentPassword { get; set; }

    [Display(Name = "کلمه عبور ")]
    [Required(ErrorMessage = "{0}  واراد نشده است.")]
    [MinLength(5,ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد.")]
    public string Password { get; set; }

    [Display(Name = "تایید کلمه عبور ")]
    [Required(ErrorMessage = "{0}  واراد نشده است.")]
    [Compare("Password", ErrorMessage = "کلمه عبور با تایید آن برابر نیست.")]
    public string ConfirmPassword { get; set; }
}
using System.ComponentModel.DataAnnotations;
using Common.L2.Application.Validation.CustomValidation.IFormFile;
using Shop.L1.Domain.User_Aggregate.Enums;

namespace Shop.Api.ViewModels.Users;

public class EditUserViewModel
{        
    [Display(Name = "نام")]
    [Required(ErrorMessage = "{0}  واراد نشده است.")]
    public string Name { get;  set; }
    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "{0}  واراد نشده است.")]
    public string Family { get;  set; }
    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "{0}  واراد نشده است.")]
    public string PhoneNumber { get;  set; }
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "{0}  واراد نشده است.")]
    public string Email { get;  set; }
    [Display(Name = "عکس پروفایل")]
    [FileImage(ErrorMessage = "تصویر پروفایل نامعتبر است.")]
    public IFormFile? Avatar { get;  set; }

    public Gender Gender { get; set; } = Gender.None;
}
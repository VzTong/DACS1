using MoviePJ.Attributes;
using MoviePJ.WebConfig.Consts;
using System.ComponentModel.DataAnnotations;

namespace MoviePJ.Areas.Admin.ViewModels.Account
{
    public class AdminProfileVM
    {
        public string? Username { get; set; }

        public string FullName { get; set; }

        [AppPhone]
        public string PhoneNumber1 { get; set; }

        [AppPhone]
        public string PhoneNumber2 { get; set; }

        [AppEmail]
        public string Email { get; set; }

        [AppRequired]
        public string Address { get; set; }

        public string? Avatar { get; set; }
        public IFormFile? AvatarUpload { get; set; }

        [DataType(DataType.Password)]
        public string? Pwd { get; set; }

        [DataType(DataType.Password)]
        [AppMinLength(VM.UserVM.PWD_MINLEN)]
        public string? NewPwd { get; set; }

        [DataType(DataType.Password)]
        [AppConfirmPwd("NewPwd")]
        public string? ConfirmPassword { get; set; }

        public bool LogoutAfterChangePwd { get; set; }
    }
}

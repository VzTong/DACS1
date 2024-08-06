using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MoviePJ.Consts;
using MoviePJ.Attributes;
using MoviePJ.WebConfig.Consts;
using MoviePJ.Attributes;
using System.ComponentModel;

namespace MoviePJ.ViewModels.Account
{
	[Index("Username", IsUnique = true)]

	public class RegisterVM
	{
		[AppUsername]
		[AppStringLength(VM.UserVM.USERNAME_MINLEN, DB.AppUser.FULLNAME_LENGTH)]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[AppStringLength(VM.UserVM.PWD_MINLEN, DB.AppUser.PWD_LENGTH)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]

		[AppConfirmPwd("Password")]
		public string ConfirmPwd { get; set; }
	
		public byte[]? PasswordHash { get; internal set; }
		public byte[]? PasswordSalt { get; internal set; }
	}
}

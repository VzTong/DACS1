using MoviePJ.Attributes;
using MoviePJ.WebConfig.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePJ.Areas.Admin.ViewModels.Role
{
    public class RoleDeleteVM
	{
		public RoleDeleteVM()
		{
			AppUsers = new List<RoleDeleteVM_User>();
		}
		public int Id { get; set; }

		[AppRequired(ErrorMessage = VM.RoleVM.NEWID_REQUIRED_ERR_MESG)]
		public int NewId { get; set; }
		public string Name { get; set; }
		public string? Desc { get; set; }
		public bool? CanDelete { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }

		public List<RoleDeleteVM_User> AppUsers { get; set; }
	}

	public class RoleDeleteVM_User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public DateTime? DeletedDate { get; set; }
	}
}

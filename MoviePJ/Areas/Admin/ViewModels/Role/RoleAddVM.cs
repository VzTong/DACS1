using MoviePJ.Attributes;
using MoviePJ.Consts;
using MoviePJ.WebConfig.Consts;

namespace MoviePJ.Areas.Admin.ViewModels.Role
{
	public class RoleAddVM
	{

		[AppRequired]
		[AppMaxLength(DB.AppRole.NAME_LENGTH)]
		public string Name { get; set; }

		[AppRequired]
		[AppMaxLength(DB.AppRole.DESC_LENGTH)]
		public string? Desc { get; set; }

		// Chuỗi chứa permissionId, phân tách bởi dấu phẩy
		[AppRequired(ErrorMessage = VM.RoleVM.PERMISSION_IDS_REQUIRED_ERR_MESG)]
		[AppRegex(VM.RoleVM.PERMISSION_IDS_REGEX, ErrorMessage = VM.RoleVM.PERMISSION_IDS_REGEX_ERR_MESG)]
		public string PermissionIds { get; set; }
	}
}

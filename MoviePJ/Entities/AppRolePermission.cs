using MoviePJ.Entities.Base;

namespace MoviePJ.Entities
{
    public class AppRolePermission : AppEntityBase
    {
        public int AppRoleId { get; set; }
        public int MstPermissionId { get; set; }
        public AppRole AppRole { get; set; }
        public MstPermission MstPermission { get; set; }
    }
}

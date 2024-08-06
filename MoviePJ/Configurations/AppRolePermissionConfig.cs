using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
	public class AppRolePermissionConfig : IEntityTypeConfiguration<AppRolePermission>
	{
		public void Configure(EntityTypeBuilder<AppRolePermission> builder)
		{
			builder.ToTable(DB.AppRolePermission.TABLE_NAME);

			// Khóa chính
			builder.HasKey(m => m.Id);

			// Khóa ngoại
			builder.HasOne(m => m.AppRole)
				.WithMany(m => m.AppRolePermissions)
				.HasForeignKey(m => m.AppRoleId);
			//.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(m => m.MstPermission)
				.WithMany(m => m.AppRolePermissions)
				.HasForeignKey(m => m.MstPermissionId);
			//.OnDelete(DeleteBehavior.NoAction);
		}
	}
}

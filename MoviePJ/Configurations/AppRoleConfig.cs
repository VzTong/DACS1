using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
	public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
	{
		public void Configure(EntityTypeBuilder<AppRole> builder)
		{
			builder.ToTable(DB.AppRole.TABLE_NAME);

			// Khóa chính
			builder.HasKey(m => m.Id);

			builder.Property(m => m.Name)
				.HasMaxLength(DB.AppRole.NAME_LENGTH)
				.IsRequired();

			builder.Property(m => m.Desc)
				.HasMaxLength(DB.AppRole.DESC_LENGTH)
				.IsRequired();
		}
	}
}

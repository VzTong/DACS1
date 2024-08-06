using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
	public class AppActorConfig : IEntityTypeConfiguration<AppActor>
	{
		public void Configure(EntityTypeBuilder<AppActor> builder)
		{
			builder.ToTable(DB.AppActor.TABLE_NAME);

			// PK
			builder.HasKey(m => m.Id);

			builder.Property(m => m.FullName)
				.HasMaxLength(DB.AppActor.FULLNAME_LENGTH)
				.IsRequired(); //NOT NULL

			builder.Property(m => m.Avatar)
				.HasMaxLength(DB.AppActor.AVATAR_LENGTH);

			// FK => AppFilm thông qua bảng phụ
		}
	}
}

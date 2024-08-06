using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
    public class AppStudioConfig : IEntityTypeConfiguration<AppStudio>
    {
        public void Configure(EntityTypeBuilder<AppStudio> builder)
        {
            builder.ToTable(DB.AppStudio.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasMaxLength(DB.AppStudio.NAME_LENGTH)
                .IsRequired();
            
            builder.Property(m => m.Cover)
                .HasMaxLength(DB.AppStudio.COVER_LENGHT);

            // FK => AppFilm thông qua bảng phụ
        }
    }
}

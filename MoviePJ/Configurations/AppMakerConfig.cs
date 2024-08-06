using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
    public class AppMakerConfig : IEntityTypeConfiguration<AppMaker>
    {
        public void Configure(EntityTypeBuilder<AppMaker> builder) 
        {
            builder.ToTable(DB.AppMaker.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            builder.Property(m => m.FullName)
                .HasMaxLength(DB.AppMaker.FULLNAME_LENGTH)
                .IsRequired();
            
            builder.Property(m => m.Avatar)
                .HasMaxLength(DB.AppMaker.AVATAR_LENGTH);

            // FK => AppFilm thông qua bảng phụ
        }
    }
}

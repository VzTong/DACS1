using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
    public class AppCommentConfig : IEntityTypeConfiguration<AppComment>
    {
        public void Configure(EntityTypeBuilder<AppComment> builder)
        {
            builder.ToTable(DB.AppComment.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Comment)
                .HasMaxLength(DB.AppComment.COMMENT_LENGTH)
                .IsRequired();

            // FK => AppFilm
            builder.HasOne(m => m.AppFilm)
                .WithMany(m => m.AppComments)
                .HasForeignKey(m => m.FilmId);

            // FK => AppUser thông qua bảng phụ
        }
    }
}

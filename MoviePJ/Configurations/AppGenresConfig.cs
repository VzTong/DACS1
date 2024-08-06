using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
    public class AppGenresConfig : IEntityTypeConfiguration<AppGenres>
    {
        public void Configure(EntityTypeBuilder<AppGenres> builder)
        {
            builder.ToTable(DB.AppGenres.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasMaxLength(DB.AppGenres.NAME_LENGTH)
                .IsRequired();

            builder.Property(m => m.Desc)
                .HasMaxLength(DB.AppGenres.DESC_LENGTH);

            builder.Property(m => m.Slug)
               .HasMaxLength(DB.AppGenres.SLUG_CATEGORY);

            builder.Property(s => s.CateLevel)
                .HasMaxLength(DB.AppGenres.LENGTH_LEVEL)
                .HasDefaultValue(1);

            builder.Property(s => s.HasChild)
                .HasDefaultValue(DB.AppGenres.DEFAULT_VALUE);

            builder.HasOne(s => s.ParentCategory)
                .WithMany(s => s.ChildCategories)
                .HasForeignKey(s => s.ParentCateId)
                .OnDelete(DeleteBehavior.NoAction);

            // FK => AppFilm thông qua bảng phụ
        }
    }
}

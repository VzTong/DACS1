using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
    public class AppNewsConfig : IEntityTypeConfiguration<AppNews>
    {
        public void Configure(EntityTypeBuilder<AppNews> builder)
        {
            builder.ToTable(DB.AppNews.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title)
                .HasMaxLength(DB.AppNews.TITLE_LENGTH)
                .IsRequired();

            builder.Property(m => m.Slug)
                .HasMaxLength(DB.AppNews.MAX_LENGTH)
                .IsRequired();

            builder.HasIndex(m => m.Slug, $"uq_slug")
                .IsUnique();

            builder.Property(m => m.Summary)
                .HasMaxLength(DB.AppNews.SUMMARY_LENGTH);

            builder.Property(m => m.Views)
                .HasDefaultValue(DB.AppNews.COUNT);

            builder.Property(m => m.Votes)
                .HasDefaultValue(DB.AppNews.COUNT);

            builder.Property(m => m.Published)
                .HasDefaultValue(DB.AppNews.PUBLIC_NEWS);

            builder.Property(m => m.PublishedAt)
                .HasDefaultValue(DB.AppNews.DEFAULT_VALUE);

            builder.Property(m => m.Cover)
                .HasMaxLength(DB.AppNews.COVER_LENGTH);

            builder.Property(m => m.CoverThumbnail)
                .HasMaxLength(DB.AppNews.COVER_LENGTH);

            builder.Property(m => m.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql(DB.AppNews.DEFAULT_DATE);

            builder.HasOne(m => m.Users)
                .WithMany(m => m.AppNews)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
    public class AppFilmConfig : IEntityTypeConfiguration<AppFilm>
    {
        public void Configure(EntityTypeBuilder<AppFilm> builder)
        {
            builder.ToTable(DB.AppFilm.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasMaxLength(DB.AppFilm.NAME_LENGTH)
                .IsRequired();

            builder.Property(m => m.AnotherName)
                .HasMaxLength(DB.AppFilm.ANOTHERNAME_LENGTH);

            builder.Property(m => m.Desc)
                .HasMaxLength(DB.AppFilm.DESC_LENGHT);

			builder.Property(m => m.Slug)
			   .HasMaxLength(DB.AppFilm.SLUG_LENGTH);

			builder.Property(m => m.Cover)
                .HasMaxLength(DB.AppFilm.COVER_LENGTH);

            builder.Property(m => m.ReleaseYear)
                .HasMaxLength(DB.AppFilm.RELEASE_YEAR_LENGTH)
                .IsRequired();

            builder.Property(m => m.Time)
                .HasMaxLength(DB.AppFilm.TIME_LENGTH);

            builder.Property(m => m.EpisodeCount)
                .HasMaxLength(DB.AppFilm.EP_LENGTH)
				.HasDefaultValue(0);

            builder.Property(m => m.Country)
                .HasMaxLength(DB.AppFilm.COUNTRY_LENGTH)
                .IsRequired();

            builder.Property(m => m.Language)
                .HasMaxLength(DB.AppFilm.LANGUAGE_LENGTH)
                .IsRequired();

            builder.Property(m => m.IsActive)
                .HasDefaultValue(DB.AppFilm.ISACTIVE)
                .IsRequired();

            // FK => Appstatus
            builder.HasOne(m => m.AppStatus)
                .WithMany(m => m.AppFilms)
                .HasForeignKey(m => m.StatusId);

			// FK => AppEpisode bên Episode
			// FK => AppComments bên Comment
			// Fk => AppStudio thông qua bảng phụ
			// FK => AppFilmmakerConfig thông qua bảng phụ
			// FK => AppActor thông qua bảng phụ
			// FK => AppGenres thông qua bảng phụ
		}
	}
}

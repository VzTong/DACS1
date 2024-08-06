using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
    public class AppGenresFilmConfig : IEntityTypeConfiguration<AppGenresFilm>
    {
        public void Configure(EntityTypeBuilder<AppGenresFilm> builder)
        {
            builder.ToTable(DB.AppGenresFilm.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            // FK => AppGenres
            builder.HasOne(m => m.AppGenres)
                .WithMany(m => m.AppGenresFilms)
                .HasForeignKey(m => m.GenresId)
                .OnDelete(DeleteBehavior.NoAction);

			// FK => AppFilm
			builder.HasOne(m => m.AppFilm)
                .WithMany(m => m.AppGenresFilms)
                .HasForeignKey(m => m.FilmId)
                .OnDelete(DeleteBehavior.NoAction);
		}
	}
}

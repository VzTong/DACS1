using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
    public class AppStudioFilmConfig : IEntityTypeConfiguration<AppStudioFilm>
    {
        public void Configure(EntityTypeBuilder<AppStudioFilm> builder)
        {
            builder.ToTable(DB.AppStudioFilm.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            // FK => AppFilm
            builder.HasOne(m => m.AppFilm)
                .WithMany(m => m.AppStudioFilms)
                .HasForeignKey(m => m.FilmId);

            // FK => AppStudio
            builder.HasOne(m => m.AppStudio)
                .WithMany(m => m.AppStudioFilms)
                .HasForeignKey(m => m.StudioId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
    public class AppFilmmakerConfig : IEntityTypeConfiguration<AppFilmmaker>
    {
        public void Configure(EntityTypeBuilder<AppFilmmaker> builder)
        {
            builder.ToTable(DB.AppFilmmaker.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            // FK => AppFilm
            builder.HasOne(m => m.AppFilm)
                .WithMany(m => m.AppFilmmakers)
                .HasForeignKey(m => m.FilmId)
                .OnDelete(DeleteBehavior.NoAction);

			// FK => AppMaker
			builder.HasOne(m => m.AppMaker)
                .WithMany(m => m.AppFilmmakers)
                .HasForeignKey(m => m.MakerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
    public class AppFilmActorsConfig : IEntityTypeConfiguration<AppFilmActor>
    {
        public void Configure(EntityTypeBuilder<AppFilmActor> builder)
        {
            builder.ToTable(DB.AppFilmActors.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            // FK => AppActor
            builder.HasOne(m => m.AppActor)
                .WithMany(m => m.AppFilmActors)
                .HasForeignKey(m => m.AppActorId)
                .OnDelete(DeleteBehavior.NoAction);

			// FK => AppFilm
			builder.HasOne(m => m.AppFilm)
                .WithMany(m => m.AppFilmActors)
                .HasForeignKey(m => m.AppFilmId)
                .OnDelete(DeleteBehavior.NoAction);
		}
	}
}

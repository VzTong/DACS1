using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
    public class AppEpisodeConfig : IEntityTypeConfiguration<AppEpisode>
    {
        public void Configure(EntityTypeBuilder<AppEpisode> builder)
        {
            builder.ToTable(DB.AppEpisode.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            builder.Property(m => m.EpNumber)
                .HasMaxLength(DB.AppEpisode.EPNUMBER_LENGTH)
                .IsRequired();

            // FK => AppFilm
            builder.HasOne(m => m.AppFilm)
                .WithMany(m => m.AppEpisodes)
                .HasForeignKey(m => m.FilmId)
                .OnDelete(DeleteBehavior.NoAction);
		}
    }
}

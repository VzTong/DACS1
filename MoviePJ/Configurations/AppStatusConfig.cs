using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.Configurations
{
    public class AppStatusConfig : IEntityTypeConfiguration<AppStatus>
    {
        public void Configure(EntityTypeBuilder<AppStatus> builder)
        {
            builder.ToTable(DB.AppStatus.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasMaxLength(DB.AppStatus.NAME_LENGTH)
                .IsRequired();

            builder.Property(m => m.Desc)
                .HasMaxLength(DB.AppStatus.DESC_LENGTH);

            // Fk => AppFilm bên AppFilm
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.DataSeeders
{
    public static class AppStatusSeeder
    {
        public static void SeedData(this EntityTypeBuilder<AppStatus> builder)
        {
            var now = new DateTime(year: 2024, month: 04, day: 01);
            builder.HasData(
                new AppStatus
                {
                    Id = DB.AppStatus.STATUS_PROCESSING,
                    Name = DB.AppStatus.STATUS_PROCESSING_NAME,
                    CreatedDate = now
                },
                new AppStatus
                {
                    Id = DB.AppStatus.STATUS_DONE,
                    Name = DB.AppStatus.STATUS_DONE_NAME,
                    CreatedDate = now
                });
        }
    }
}

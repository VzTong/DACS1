using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Entities;

namespace MoviePJ.DataSeeders
{
    public static class AppRoleSeeder
    {
        public static void SeedData(this EntityTypeBuilder<AppRole> builder)
        {
            var now = new DateTime(year: 2024, month: 04, day: 01);

            // Tạo vai trò
            var roleAdmin = new AppRole
            {
                Id = 1,
                Name = "Admin",
                Desc = "Administer the entire system",
                CreatedDate = now,
                UpdatedDate = now,
                CanDelete = true
            };
            var roleUser = new AppRole
            {
                Id = 2,
                Name = "User",
                Desc = "User",
                CreatedDate = now,
                UpdatedDate = now,
                CanDelete = false
            };

            builder.HasData(roleAdmin, roleUser);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Entities;
using System.Security.Cryptography;
using System.Text;

namespace MoviePJ.DataSeeders
{
    public static class AppUserSeeder
    {
        public static void SeedData(this EntityTypeBuilder<AppUser> builder)
        {
            var now = new DateTime(year: 2024, month: 04, day: 01);

            //Tạo mật khẩu
            var defaultPassword = "123123";
            HMACSHA512 hmac = new();
            var pwByte = Encoding.UTF8.GetBytes(defaultPassword);
            var pwdHash = hmac.ComputeHash(pwByte);
            var pwdSalt = hmac.Key;

            // Tạo thông tin tài khoản Admin
            builder.HasData(
                new AppUser
                {
                    Id = 1,
                    Username = "admin",
                    PasswordHash = pwdHash,
                    PasswordSalt = pwdSalt,
                    Address = "City New",
                    Email = "admin_test@gmail.com",
                    FullName = "Administrator",
                    PhoneNumber1 = "0987654321",
                    PhoneNumber2 = "0987654321",
                    Avatar = "upload/img_avt/avt_default.png",
                    CreatedBy = -1,
                    UpdatedBy = -1,
                    UpdatedDate = now,
                    CreatedDate = now,
                    AppRoleId = 1,				// Vai trò được tạo ở AppRoleSeeder
                },
                
                new AppUser
                {
                    Id = 2,
                    Username = "User1",
                    PasswordHash = pwdHash,
                    PasswordSalt = pwdSalt,
                    Address = "City new",
                    Email = "user_test@gmail.com",
                    FullName = "User One",
                    PhoneNumber1 = "0123456789",
                    PhoneNumber2 = "0123456789",
                    Avatar = "upload/img_avt/avt_default.png",
                    CreatedBy = -1,
                    UpdatedBy = -1,
                    UpdatedDate = now,
                    CreatedDate = now,
                    AppRoleId = 2,				// Vai trò được tạo ở AppRoleSeeder
                }
            );
        }
    }
}

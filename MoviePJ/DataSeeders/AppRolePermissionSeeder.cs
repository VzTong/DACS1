using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;
using System.Reflection;

namespace MoviePJ.DataSeeders
{
    public static class AppRolePermissionSeeder
    {
        public static void SeedData(this EntityTypeBuilder<AppRolePermission> builder)
        {
            var now = new DateTime(year: 2024, month: 04, day: 01);

            // Danh sách các class chứa permission
            Type[] classType = new Type[]
            {
                typeof(AuthConst.AppRole),
                typeof(AuthConst.AppUser),
                typeof(AuthConst.AppNews),
                typeof(AuthConst.AppGenres),
                typeof(AuthConst.AppFilm),
                typeof(AuthConst.AppActor),
                typeof(AuthConst.AppMaker),
                typeof(AuthConst.AppStudio),
                typeof(AuthConst.AppEpisode),
                typeof(AuthConst.AppComment),

				//Không thêm data vào đây vì ảnh hưởng đến production, không update-database được
            };

            // Cấp quyền cho vai trò
            var rolePermission = new List<AppRolePermission>();
            int i = 0;
            foreach (var type in classType)
            {
                var allPermission = GetConstants(type);
                foreach (var permission in allPermission)
                {
                    i++;
                    rolePermission.Add(new AppRolePermission
                    {
                        Id = i,
                        MstPermissionId = Convert.ToInt32(permission.GetRawConstantValue()),
                        UpdatedDate = now,
                        CreatedDate = now,
                        AppRoleId = 1, 		// Vai trò được tạo ở AppRoleSeeder
                    });
                }
            }

            builder.HasData(rolePermission);
        }

        private static List<FieldInfo> GetConstants(Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public |
                BindingFlags.Static | BindingFlags.FlattenHierarchy);

            return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList();
        }
    }
}

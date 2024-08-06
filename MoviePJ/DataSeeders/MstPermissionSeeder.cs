using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;

namespace MoviePJ.DataSeeders
{
    public static class MstPermissionSeeder
    {
        public static void SeedData(this EntityTypeBuilder<MstPermission> builder)
        {
            var now = new DateTime(year: 2024, month: 04, day: 01);
            var groupName = "";

            #region Data liên quan đến bảng Role
            // Permission liên quan đến bảng AppRole
            // Quản lý phân quyền
            groupName = "Decentralized management";
            builder.HasData(
                new MstPermission
                {
                    Id = AuthConst.AppRole.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = DB.AppRole.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "See permissions list",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppRole.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = DB.AppRole.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "View permission details",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppRole.CREATE,
                    Code = "CREATE",
                    Table = DB.AppRole.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Add permissions",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppRole.UPDATE,
                    Code = "UPDATE",
                    Table = DB.AppRole.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Modify the permission",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppRole.DELETE,
                    Code = "DELETE",
                    Table = DB.AppRole.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Remove permissions",
                    CreatedDate = now
                }
            );
            #endregion

            #region Data liên quản bảng User
            // Permission liên quan đến bảng AppUser
            // Quản lý tài khoản
            groupName = "Account Management";
            builder.HasData(
                new MstPermission
                {
                    Id = AuthConst.AppUser.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = DB.AppUser.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "View user list",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppUser.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = DB.AppUser.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "View user details",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppUser.CREATE,
                    Code = "CREATE",
                    Table = DB.AppUser.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Add users",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppUser.UPDATE,
                    Code = "UPDATE",
                    Table = DB.AppUser.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Update user",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppUser.UPDATE_PWD,
                    Code = "UPDATE_PWD",
                    Table = DB.AppUser.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Change Password",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppUser.BLOCK,
                    Code = "BLOCK",
                    Table = DB.AppUser.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Lock user",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppUser.UNBLOCK,
                    Code = "UNBLOCK",
                    Table = DB.AppUser.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Unlock users",
                    CreatedDate = now
                }
            );
            #endregion

            #region Data quản lý tin tức
            // Permission liên quan đến bảng AppNews
            //Quản lý tin tức
            groupName = "News Management";
            builder.HasData(
                new MstPermission
                {
                    Id = AuthConst.AppNews.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = DB.AppNews.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "See article list",
                    CreatedDate = now
                },
                 new MstPermission
                 {
                     Id = AuthConst.AppNews.VIEW_DETAIL,
                     Code = "VIEW_DETAIL",
                     Table = DB.AppNews.TABLE_NAME,
                     GroupName = groupName,
                     Desc = "See article detail",
                     CreatedDate = now
                 },
                new MstPermission
                {
                    Id = AuthConst.AppNews.CREATE,
                    Code = "CREATE",
                    Table = DB.AppNews.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Add articles",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppNews.UPDATE,
                    Code = "UPDATE",
                    Table = DB.AppNews.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Update article",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppNews.DELETE,
                    Code = "DELETE",
                    Table = DB.AppNews.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Update article",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppNews.PUBLIC,
                    Code = "PUBLIC",
                    Table = DB.AppNews.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Publish the article",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppNews.UNPUBLIC,
                    Code = "UNPUBLIC",
                    Table = DB.AppNews.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Remove the article",
                    CreatedDate = now
                }

                );
            #endregion

            #region quản lý danh mục
            // Permission liên quan đến bảng AppGenres
            //Quản lý danh mục
            groupName = "Category management";
            builder.HasData(
                new MstPermission
                {
                    Id = AuthConst.AppGenres.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = DB.AppGenres.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "View category list",
                    CreatedDate = now
                },
                 new MstPermission
                 {
                     Id = AuthConst.AppGenres.VIEW_DETAIL,
                     Code = "VIEW_DETAIL",
                     Table = DB.AppGenres.TABLE_NAME,
                     GroupName = groupName,
                     Desc = "View genre details",
                     CreatedDate = now
                 },
                new MstPermission
                {
                    Id = AuthConst.AppGenres.CREATE,
                    Code = "CREATE",
                    Table = DB.AppGenres.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Add categories",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppGenres.UPDATE,
                    Code = "UPDATE",
                    Table = DB.AppGenres.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Update categories",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppGenres.DELETE,
                    Code = "DELETE",
                    Table = DB.AppGenres.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Delete category",
                    CreatedDate = now
                }
                );
            #endregion

            #region Quản lý Film
            // Permission liên quan đến bảng AppFilm
            //Quản lý film
            groupName = "Film management";
            builder.HasData(
                new MstPermission
                {
                    Id = AuthConst.AppFilm.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = DB.AppFilm.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Manage movie lists",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppFilm.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = DB.AppFilm.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "View film details",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppFilm.CREATE,
                    Code = "CREATE",
                    Table = DB.AppFilm.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Add",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppFilm.UPDATE,
                    Code = "UPDATE",
                    Table = DB.AppFilm.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Update",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppFilm.DELETE,
                    Code = "DELETE",
                    Table = DB.AppFilm.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Delete",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppFilm.PUBLIC,
                    Code = "PUBLIC",
                    Table = DB.AppFilm.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Public",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppFilm.UNPUBLIC,
                    Code = "UNPUBLIC",
                    Table = DB.AppFilm.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Unpublic",
                    CreatedDate = now
                });
            #endregion

            #region Quản lý Actor
            // Permission liên quan đến bảng AppActor
            //Quản lý movie
            groupName = "Actor management";
            builder.HasData(
                new MstPermission
                {
                    Id = AuthConst.AppActor.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = DB.AppActor.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Manage movie lists",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppActor.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = DB.AppActor.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "View actor details",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppActor.CREATE,
                    Code = "CREATE",
                    Table = DB.AppActor.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Add",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppActor.UPDATE,
                    Code = "UPDATE",
                    Table = DB.AppActor.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Update",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppActor.DELETE,
                    Code = "DELETE",
                    Table = DB.AppActor.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Delete",
                    CreatedDate = now
                });

            #endregion

            #region Quản lý Filmmaker
            // Permission liên quan đến bảng AppMaker
            //Quản lý filmmaker
            groupName = "Filmmaker management";
            builder.HasData(
                new MstPermission
                {
                    Id = AuthConst.AppMaker.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = DB.AppMaker.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Manage movie lists",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppMaker.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = DB.AppMaker.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "View filmmaker details",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppMaker.CREATE,
                    Code = "CREATE",
                    Table = DB.AppMaker.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Add",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppMaker.UPDATE,
                    Code = "UPDATE",
                    Table = DB.AppMaker.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Update",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppMaker.DELETE,
                    Code = "DELETE",
                    Table = DB.AppMaker.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Delete",
                    CreatedDate = now
                });
            #endregion

            #region Quản lý Studio
            // Permission liên quan đến bảng AppStudio
            //Quản lý studio
            groupName = "Studio management";
            builder.HasData(
                new MstPermission
                {
                    Id = AuthConst.AppStudio.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = DB.AppStudio.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Manage movie lists",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppStudio.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = DB.AppStudio.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "View studio details",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppStudio.CREATE,
                    Code = "CREATE",
                    Table = DB.AppStudio.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Add",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppStudio.UPDATE,
                    Code = "UPDATE",
                    Table = DB.AppStudio.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Update",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppStudio.DELETE,
                    Code = "DELETE",
                    Table = DB.AppStudio.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Delete",
                    CreatedDate = now
                });
            #endregion

            #region Quản lý Episode
            // Permission liên quan đến bảng AppEpisode
            //Quản lý Episode
            groupName = "Episode management";
            builder.HasData(
                new MstPermission
                {
                    Id = AuthConst.AppEpisode.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = DB.AppEpisode.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Manage movie lists",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppEpisode.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = DB.AppEpisode.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "View actor details",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppEpisode.CREATE,
                    Code = "CREATE",
                    Table = DB.AppEpisode.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Add",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppEpisode.UPDATE,
                    Code = "UPDATE",
                    Table = DB.AppEpisode.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Update",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppEpisode.DELETE,
                    Code = "DELETE",
                    Table = DB.AppEpisode.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Delete",
                    CreatedDate = now
                });
            #endregion

            #region Quản lý Comment
            // Permission liên quan đến bảng AppComment
            //Quản lý Comment
            groupName = "Comment management";
            builder.HasData(
                new MstPermission
                {
                    Id = AuthConst.AppComment.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = DB.AppComment.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Manage movie lists",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppComment.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = DB.AppComment.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "View comment details",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppComment.CREATE,
                    Code = "CREATE",
                    Table = DB.AppComment.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Add",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppComment.UPDATE,
                    Code = "UPDATE",
                    Table = DB.AppComment.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Update",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppComment.DELETE,
                    Code = "DELETE",
                    Table = DB.AppComment.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Delete",
                    CreatedDate = now
                });
            #endregion

            #region Quản lý Status
            // Permission liên quan đến bảng AppComment
            //Quản lý Comment
            groupName = "Comment management";
            builder.HasData(
                new MstPermission
                {
                    Id = AuthConst.AppStatus.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = DB.AppStatus.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Manage movie lists",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppStatus.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = DB.AppStatus.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "View comment details",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppStatus.CREATE,
                    Code = "CREATE",
                    Table = DB.AppStatus.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Add",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppStatus.UPDATE,
                    Code = "UPDATE",
                    Table = DB.AppStatus.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Update",
                    CreatedDate = now
                },
                new MstPermission
                {
                    Id = AuthConst.AppStatus.DELETE,
                    Code = "DELETE",
                    Table = DB.AppStatus.TABLE_NAME,
                    GroupName = groupName,
                    Desc = "Delete",
                    CreatedDate = now
                });
            #endregion
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MoviePJ.Configurations;
using MoviePJ.DataSeeders;

namespace MoviePJ.Entities
{
    public class MoviePJ_DBContext : DbContext
    {
        public DbSet<AppActor> AppActors { get; set; }
        public DbSet<AppComment> AppComments { get; set;}
        public DbSet<AppCommentDetail> AppCommentsDetail { get; set;}
        public DbSet<AppEpisode> AppEpisodes { get; set;}
        public DbSet<AppFilm> AppFilms { get; set;}
        public DbSet<AppFilmActor> AppFilmActors { get; set;}
        public DbSet<AppFilmmaker> AppFilmmaker { get; set;}
        public DbSet<AppGenres> AppGenres { get; set;}
        public DbSet<AppGenresFilm> AppGenresFilms { get; set;}
        public DbSet<AppMaker> AppMaker { get; set;}
        public DbSet<AppNews> AppNews { get; set;}
        public DbSet<AppRole> AppRole { get; set;}
        public DbSet<AppRolePermission> AppRolePermission { get; set;}
        public DbSet<AppStatus> AppStatus { get; set;}
        public DbSet<AppStudio> AppStudio { get; set;}
        public DbSet<AppStudioFilm> AppStudioFilm { get; set;}
        public DbSet<AppUser> AppUser { get; set;}
        public DbSet<MstPermission> MstPermission { get; set;}

        public MoviePJ_DBContext(DbContextOptions<MoviePJ_DBContext> options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MstPermissionConfig());
            modelBuilder.ApplyConfiguration(new AppRoleConfig());
            modelBuilder.ApplyConfiguration(new AppUserConfig());
            modelBuilder.ApplyConfiguration(new AppRolePermissionConfig());
            modelBuilder.ApplyConfiguration(new AppGenresConfig());
            modelBuilder.ApplyConfiguration(new AppStatusConfig());
            modelBuilder.ApplyConfiguration(new AppActorConfig());
            modelBuilder.ApplyConfiguration(new AppMakerConfig());
            modelBuilder.ApplyConfiguration(new AppStudioConfig());
            modelBuilder.ApplyConfiguration(new AppFilmConfig());
            modelBuilder.ApplyConfiguration(new AppFilmActorsConfig());
            modelBuilder.ApplyConfiguration(new AppFilmmakerConfig());
            modelBuilder.ApplyConfiguration(new AppStudioFilmConfig());
            modelBuilder.ApplyConfiguration(new AppGenresFilmConfig());
            modelBuilder.ApplyConfiguration(new AppCommentConfig());
            modelBuilder.ApplyConfiguration(new AppCommentDetailConfig());
            modelBuilder.ApplyConfiguration(new AppEpisodeConfig());
            modelBuilder.ApplyConfiguration(new AppNewsConfig());

            // Tạo dữ liệu
            modelBuilder.Entity<MstPermission>().SeedData();
            modelBuilder.Entity<AppRole>().SeedData();
            modelBuilder.Entity<AppUser>().SeedData();
            modelBuilder.Entity<AppGenres>().SeedData();
            modelBuilder.Entity<AppStatus>().SeedData();
            modelBuilder.Entity<AppActor>().SeedData();
            modelBuilder.Entity<AppMaker>().SeedData();
            modelBuilder.Entity<AppStudio>().SeedData();
            modelBuilder.Entity<AppFilm>().SeedData();
            modelBuilder.Entity<AppFilmActor>().SeedData();
            modelBuilder.Entity<AppFilmmaker>().SeedData();
            modelBuilder.Entity<AppStudioFilm>().SeedData();
            modelBuilder.Entity<AppGenresFilm>().SeedData();
            modelBuilder.Entity<AppEpisode>().SeedData();
            modelBuilder.Entity<AppRolePermission>().SeedData();
        }
    }
}

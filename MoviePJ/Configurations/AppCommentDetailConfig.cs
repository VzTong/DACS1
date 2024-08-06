using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviePJ.Consts;
using MoviePJ.Entities;
using MoviePJ.Entities.Base;

namespace MoviePJ.Configurations
{
    public class AppCommentDetailConfig : IEntityTypeConfiguration<AppCommentDetail>
    {
        public void Configure(EntityTypeBuilder<AppCommentDetail> builder) 
        {
            builder.ToTable(DB.AppCommentDetail.TABLE_NAME);

            // PK
            builder.HasKey(m => m.Id);

            // FK => AppUser
            builder.HasOne(m => m.AppUser)
                .WithMany(m => m.AppCommentDetails)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.NoAction);

			// FK => AppComment
			builder.HasOne(m => m.AppComment)
                .WithMany(m => m.AppCommentDetails)
                .HasForeignKey(m => m.CommentId)
                .OnDelete(DeleteBehavior.NoAction);
		}
	}
}

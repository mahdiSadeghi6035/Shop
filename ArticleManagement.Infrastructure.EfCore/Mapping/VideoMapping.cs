using ArticleManagement.Domain.VideoAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleManagement.Infrastructure.EfCore.Mapping
{
    public class VideoMapping : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("Video");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PictureTitle).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.KeyWords).IsRequired();
            builder.Property(x => x.MetaDescription).IsRequired();

            builder.HasOne(x => x.VideoCategory)
                .WithMany(x => x.Video)
                .HasForeignKey(x => x.VideoCategoryId);
        }
    }
}

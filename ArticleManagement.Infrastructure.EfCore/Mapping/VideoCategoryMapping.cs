using ArticleManagement.Domain.VideoCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleManagement.Infrastructure.EfCore.Mapping
{
    public class VideoCategoryMapping : IEntityTypeConfiguration<VideoCategory>
    {
        public void Configure(EntityTypeBuilder<VideoCategory> builder)
        {
            builder.ToTable("VideoCategory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.KeyWords).IsRequired();
            builder.Property(x => x.MetaDescription).IsRequired();

            builder.HasMany(x => x.Video)
                .WithOne(x => x.VideoCategory)
                .HasForeignKey(x => x.VideoCategoryId);
        }
    }
}

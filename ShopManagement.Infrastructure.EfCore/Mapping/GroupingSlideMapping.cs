using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.GroupingSlideAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class GroupingSlideMapping : IEntityTypeConfiguration<GroupingSlide>
    {
        public void Configure(EntityTypeBuilder<GroupingSlide> builder)
        {
            builder.ToTable("GroupingSlide");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PictureAlt).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Groupings)
                .WithMany(x => x.GroupingSlides)
                .HasForeignKey(x => x.GroupingId);
        }
    }
}

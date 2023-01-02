using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slide");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PictureAlt).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(100).IsRequired();
        }
    }
}

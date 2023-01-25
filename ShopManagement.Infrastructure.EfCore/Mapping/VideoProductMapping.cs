using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.VideoProductAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class VideoProductMapping : IEntityTypeConfiguration<VideoProduct>
    {
        public void Configure(EntityTypeBuilder<VideoProduct> builder)
        {
            builder.ToTable("VideoProduct");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Video).IsRequired();
            builder.Property(x => x.Type).IsRequired();

            builder.HasOne(x => x.Products)
                .WithMany(x => x.VideoProducts)
                .HasForeignKey(x => x.ProductId);
        }
    }
}

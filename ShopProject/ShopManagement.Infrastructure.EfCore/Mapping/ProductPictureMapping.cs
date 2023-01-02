using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPicture");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PictureTitle).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Products)
                .WithMany(x => x.ProductPictures)
                .HasForeignKey(x => x.ProductId);
        }
    }
}

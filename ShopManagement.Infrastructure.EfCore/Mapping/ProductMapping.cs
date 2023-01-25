using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(150);
            builder.Property(x => x.PictureTitle).HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.Keywords).IsRequired();
            builder.Property(x => x.MetaDescription).IsRequired();
            builder.Property(x => x.Specifications).IsRequired();

            builder.HasOne(x => x.Brands)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.BrandId);

            builder.HasOne(x => x.Categorys)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.ProductPictures)
                .WithOne(x => x.Products)
                .HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.VideoProducts)
                .WithOne(x => x.Products)
                .HasForeignKey(x => x.ProductId);
        }
    }
}

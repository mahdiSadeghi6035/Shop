using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.BrandAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class BrandMapping : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(150);
            builder.Property(x => x.PictureTitle).HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.Keywords).IsRequired();
            builder.Property(x => x.MetaDescription).IsRequired();

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Brands)
                .HasForeignKey(x => x.BrandId);
        }
    }
}

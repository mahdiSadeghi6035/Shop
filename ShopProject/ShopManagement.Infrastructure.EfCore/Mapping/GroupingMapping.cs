using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.GroupingAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class GroupingMapping : IEntityTypeConfiguration<Grouping>
    {
        public void Configure(EntityTypeBuilder<Grouping> builder)
        {
            builder.ToTable("Grouping");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(150);
            builder.Property(x => x.PictureTitle).HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.Keywords).IsRequired();
            builder.Property(x => x.MetaDescription).IsRequired();
        }
    }
}

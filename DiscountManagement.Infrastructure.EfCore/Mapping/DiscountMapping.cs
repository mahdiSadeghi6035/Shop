using DiscountManagement.Domain.DiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.EfCore.Mapping
{
    public class DiscountMapping : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discount");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DiscountType).IsRequired();
            builder.Property(x => x.Rate).IsRequired();
            builder.Property(x => x.CreationDate).HasColumnName("CreationDate");
        }
    }
}

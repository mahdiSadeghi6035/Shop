using DiscountManagement.Domain.OccasionalDiscountsAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.EfCore.Mapping
{
    public class OccasionalDiscountsMapping : IEntityTypeConfiguration<OccasionalDiscounts>
    {
        public void Configure(EntityTypeBuilder<OccasionalDiscounts> builder)
        {
            builder.ToTable("OccasionalDiscounts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.OwnsMany(x => x.DiscountsProducts, navigation =>
            {
                navigation.ToTable("OccasionalDiscountsProduct");
                navigation.WithOwner(x => x.OccasionalDiscounts);
            });
        }
    }
}

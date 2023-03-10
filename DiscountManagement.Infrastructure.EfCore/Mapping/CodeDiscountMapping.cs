using DiscountManagement.Domain.CodeDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.EfCore.Mapping
{
    public class CodeDiscountMapping : IEntityTypeConfiguration<CodeDiscount>
    {
        public void Configure(EntityTypeBuilder<CodeDiscount> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("CodeDiscount");
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}

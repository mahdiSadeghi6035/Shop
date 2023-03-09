using InventoryManagement.Domain.WarrantyAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EfCore.Mapping
{
    public class WarrantyMapping : IEntityTypeConfiguration<Warranty>
    {
        public void Configure(EntityTypeBuilder<Warranty> builder)
        {
            builder.ToTable("Warranty");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.WarrantyDescription).HasMaxLength(250).IsRequired();
            builder.HasMany(x => x.Invetorys).WithOne(x => x.Warranty).HasForeignKey(x => x.WarrantyId);
        }
    }
}

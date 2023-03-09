using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.EfCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Color).HasMaxLength(100);
            builder.OwnsMany(x => x.InventoryOperation, navigation =>
            {
                navigation.ToTable("InventoryOperation");
                navigation.HasKey(x => x.Id);
                navigation.Property(x => x.Description).HasMaxLength(200).IsRequired();

                navigation.WithOwner(x => x.Inventorys).HasForeignKey(x => x.InventoryId);
            });
            builder.HasOne(x => x.Warranty).WithMany(x => x.Invetorys).HasForeignKey(x => x.WarrantyId);
        }
    }
}

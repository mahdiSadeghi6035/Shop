using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Domain.WarrantyAgg;
using InventoryManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.EfCore
{
    public class InventoryContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Warranty> Warranty{ get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

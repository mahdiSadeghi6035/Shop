using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.GroupingAgg;
using ShopManagement.Infrastructure.EfCore.Mapping;

namespace ShopManagement.Infrastructure.EfCore
{
    public class ShopContext : DbContext
    {
        public DbSet<Grouping> Groupings { get; set; }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(GroupingMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

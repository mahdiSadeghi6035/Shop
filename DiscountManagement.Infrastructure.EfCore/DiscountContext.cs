using DiscountManagement.Domain.CodeDiscountAgg;
using DiscountManagement.Domain.DiscountAgg;
using DiscountManagement.Domain.OccasionalDiscountsAgg;
using DiscountManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure.EfCore
{
    public class DiscountContext : DbContext
    {
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<OccasionalDiscounts> OccasionalDiscounts { get; set; }
        public DbSet<CodeDiscount> CodeDiscount { get; set; }
        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assambly = typeof(DiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assambly);
            base.OnModelCreating(modelBuilder);
        }

    }
}

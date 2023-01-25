using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.BrandAgg;
using ShopManagement.Domain.CategoryAgg;
using ShopManagement.Domain.GroupingAgg;
using ShopManagement.Domain.GroupingSlideAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Domain.VideoProductAgg;
using ShopManagement.Infrastructure.EfCore.Mapping;

namespace ShopManagement.Infrastructure.EfCore
{
    public class ShopContext : DbContext
    {
        public DbSet<Grouping> Groupings { get; set; }
        public DbSet<Category> Categorys{ get; set; }
        public DbSet<Brand> Brands{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures{ get; set; }
        public DbSet<Slide> Slides{ get; set; }
        public DbSet<GroupingSlide> GroupingSlides { get; set; }
        public DbSet<VideoProduct> VideoProduct{ get; set; }
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

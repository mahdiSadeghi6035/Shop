using ArticleManagement.Domain.ArticleAgg;
using ArticleManagement.Domain.ArticleCategoryAgg;
using ArticleManagement.Domain.VideoAgg;
using ArticleManagement.Domain.VideoCategoryAgg;
using ArticleManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace ArticleManagement.Infrastructure.EfCore
{
    public class ArticleContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategory{ get; set; }
        public DbSet<Article> Article{ get; set; }
        public DbSet<VideoCategory> VideoCategory{ get; set; }
        public DbSet<Video> Video{ get; set; }
        public ArticleContext(DbContextOptions<ArticleContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrstructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CommentManagement.Infrstructure.EfCore
{
    public class CommentContext : DbContext
    {
        public DbSet<Comment> Comment { get; set; }

        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assambly = typeof(CommentMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assambly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

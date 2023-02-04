using ArticleManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleManagement.Infrastructure.EfCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.KeyWords).IsRequired();
            builder.Property(x => x.MetaDescription).IsRequired();

            builder.HasMany(x => x.Articles).WithOne(x => x.ArticleCategorys).HasForeignKey(x => x.ArticleCategoryId);
        }
    }
}

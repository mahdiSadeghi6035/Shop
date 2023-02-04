using ArticleManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleManagement.Infrastructure.EfCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(150).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(150);
            builder.Property(x => x.PictureTitle).HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.KeyWords).IsRequired();
            builder.Property(x => x.MetaDescription).IsRequired();
            builder.Property(x => x.CanonicalAddress).IsRequired();

            builder.HasOne(x => x.ArticleCategorys).WithMany(x => x.Articles).HasForeignKey(x => x.ArticleCategoryId);
        }
    }
}

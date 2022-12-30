﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CategoryAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(150);
            builder.Property(x => x.PictureTitle).HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Slug).IsRequired();
            builder.Property(x => x.Keywords).IsRequired();
            builder.Property(x => x.MetaDescription).IsRequired();

            builder.HasOne(x => x.Groupings)
                .WithMany(x => x.categories)
                .HasForeignKey(x => x.GroupingId);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Categorys)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}

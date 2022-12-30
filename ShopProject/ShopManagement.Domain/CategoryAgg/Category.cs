using _0_Framework.Domain;
using ShopManagement.Domain.GroupingAgg;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.CategoryAgg
{
    public class Category : DomainBase<long>
    {
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public string MetaDescription { get; private set; }
        public string Keywords { get; private set; }
        public long GroupingId { get; private set; }
        public Grouping Groupings { get; private set; }
        public List<Product> Products { get; private set; }

        public Category(string name, string picture, string pictureAlt, string pictureTitle, string description, string slug,
            string metaDescription, string keywords, long groupingId)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            Slug = slug;
            MetaDescription = metaDescription;
            Keywords = keywords;
            GroupingId = groupingId;
            Products = new List<Product>();
        }
        public void Edit(string name, string picture, string pictureAlt, string pictureTitle, string description, string slug,
            string metaDescription, string keywords, long groupingId)
        {
            Name = name;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            Slug = slug;
            MetaDescription = metaDescription;
            Keywords = keywords;
            GroupingId = groupingId;
        }
    }
}

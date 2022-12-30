using _0_Framework.Domain;
using ShopManagement.Domain.CategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.GroupingAgg
{
    public class Grouping : DomainBase<long>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public List<Category> categories { get; private set; }

        public Grouping(string name, string description, string picture, string pictureAlt,
            string pictureTitle, string slug, string keywords, string metaDescription)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            categories = new List<Category>();
        }
        public void Edit(string name, string description, string picture, string pictureAlt,
            string pictureTitle, string slug, string keywords, string metaDescription)
        {
            Name = name;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }
    }
}

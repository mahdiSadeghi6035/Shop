using _0_Framework.Domain;
using ShopManagement.Domain.BrandAgg;
using ShopManagement.Domain.CategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : DomainBase<long>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Specifications { get; private set; }
        public Brand Brands { get; private set; }
        public long BrandId { get; private set; }
        public Category Categorys { get; private set; }
        public long CategoryId { get; private set; }
        public string Slug { get; private set; }
        public string MetaDescription { get; private set; }
        public string Keywords { get; private set; }
        public List<ProductPicture> ProductPictures{ get; private set; }

        public Product(string name, string description, string picture, string pictureAlt, string pictureTitle,
            string specifications, long brandId, long categoryId, string slug, string metaDescription, string keywords)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Specifications = specifications;
            BrandId = brandId;
            CategoryId = categoryId;
            Slug = slug;
            MetaDescription = metaDescription;
            Keywords = keywords;
            ProductPictures = new List<ProductPicture>();
        }
        public void Edit(string name, string description, string picture, string pictureAlt, string pictureTitle,
            string specifications, long brandId, long categoryId, string slug, string metaDescription, string keywords)
        {
            Name = name;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Specifications = specifications;
            BrandId = brandId;
            CategoryId = categoryId;
            Slug = slug;
            MetaDescription = metaDescription;
            Keywords = keywords;
        }
    }
}

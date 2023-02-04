using _0_Framework.Domain;
using ArticleManagement.Domain.ArticleCategoryAgg;
using System;

namespace ArticleManagement.Domain.ArticleAgg
{
    public class Article : DomainBase<long>
    {
        public string Title { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public DateTime PublishDate{ get; private set; }
        public long ArticleCategoryId { get; private set; }
        public string Description { get; private set; }
        public ArticleCategory ArticleCategorys { get; private set; }

        public Article(string title, string picture, string pictureAlt, string pictureTitle, string slug, string keyWords, string metaDescription, string canonicalAddress, DateTime publishDate, long articleCategoryId, string description)
        {
            Title = title;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            PublishDate = publishDate;
            ArticleCategoryId = articleCategoryId;
            Description = description;
        }
        public void Edit(string title, string picture, string pictureAlt, string pictureTitle, string slug, string keyWords, string metaDescription, string canonicalAddress, DateTime publishDate, long articleCategoryId, string description)
        {
            Title = title;
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            PublishDate = publishDate;
            ArticleCategoryId = articleCategoryId;
            Description = description;
        }
    }
}

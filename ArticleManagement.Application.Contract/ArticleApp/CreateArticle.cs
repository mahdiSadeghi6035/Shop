using ArticleManagement.Application.Contract.ArticleCategoryApp;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ArticleManagement.Application.Contract.ArticleApp
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
        public string PublishDate { get; set; }
        public long ArticleCategoryId { get; set; }
        public string Description { get; set; }
        public List<ViewModelArticleCategory> ModelArticleCategories{ get; set; }
    }
}

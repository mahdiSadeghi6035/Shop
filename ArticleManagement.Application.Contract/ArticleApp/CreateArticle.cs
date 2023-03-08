using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ArticleManagement.Application.Contract.ArticleApp
{
    public class CreateArticle
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Title { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessage.maxFileSizeMessage)]
        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessage.ExtentionMessage)]
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string KeyWords { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string CanonicalAddress { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PublishDate { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.RequiredMessage)]
        public long ArticleCategoryId { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Description { get; set; }
    }
}

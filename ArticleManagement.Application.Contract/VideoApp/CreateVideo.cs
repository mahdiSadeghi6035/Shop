using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ArticleManagement.Application.Contract.VideoApp
{
    public class CreateVideo
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Description { get; set; }
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessage.maxFileSizeMessage)]
        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessage.ExtentionMessage)]
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureTitle { get; set; }
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessage.maxFileSizeMessage)]
        [FileExtentionLimitation(new string[] {".mp4" }, ErrorMessage = ValidationMessage.ExtentionMessage)]
        public IFormFile Videos { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Type { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.RequiredMessage)]
        public long VideoCategoryId { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string KeyWords { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string MetaDescription { get; set; }
    }
}

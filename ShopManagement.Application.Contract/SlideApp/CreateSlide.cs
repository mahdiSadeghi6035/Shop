using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.SlideApp
{
    public class CreateSlide
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessage.maxFileSizeMessage)]
        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessage.ExtentionMessage)]
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Link { get; set; }
    }
}

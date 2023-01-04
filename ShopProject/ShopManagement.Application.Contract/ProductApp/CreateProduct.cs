using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.ProductApp
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessage.maxFileSizeMessage)]
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Description { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Specifications { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.RequiredMessage)]
        public long BrandId { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.RequiredMessage)]
        public long CategoryId { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }
    }
}

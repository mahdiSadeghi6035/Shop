using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.VideoProductApp
{
    public class CreateVideoProduct
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessage.maxFileSizeMessage)]
        [FileExtentionLimitation(new string[] { ".mp4" }, ErrorMessage = ValidationMessage.ExtentionMessage)]
        public IFormFile Video { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Type { get; set; }
        [Range(0, long.MaxValue, ErrorMessage = ValidationMessage.RequiredMessage)]
        public long ProductId { get; set; }
        public List<ViewModelProduct> ModelProducts { get; set; }
    }
}

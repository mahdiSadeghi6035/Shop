using _0_Framework.Application;
using ShopManagement.Application.Contract.BrandApp;
using ShopManagement.Application.Contract.CategoryApp;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.ProductApp
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Description { get; set; }
        public string Picture { get; set; }
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

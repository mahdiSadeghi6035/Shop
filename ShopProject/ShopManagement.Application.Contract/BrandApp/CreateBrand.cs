using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.BrandApp
{
    public class CreateBrand
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Name { get; set; }
        public string Picture { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Description { get; set; }
        public string Slug { get;  set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Keywords { get;  set; }
        public string MetaDescription { get;  set; }
    }
}

using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.ProductPictureApp
{
    public class CreateProductPicture
    {
        public string Picture { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureTitle { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.RequiredMessage)]
        public long ProductId { get; set; }
        public List<ViewModelProduct> ModelProducts{ get; set; }
    }
}

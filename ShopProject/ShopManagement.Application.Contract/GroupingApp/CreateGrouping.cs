using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.GroupingApp
{
    public class CreateGrouping
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Slug { get; set; }
        public string Keywords { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string MetaDescription { get; set; }
    }
}

using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace ArticleManagement.Application.Contract.VideoCategoryApp
{
    public class CreateVideoCategory
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string KeyWords { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string MetaDescription { get; set; }
    }
}

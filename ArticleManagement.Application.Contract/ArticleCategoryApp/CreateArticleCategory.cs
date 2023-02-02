using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace ArticleManagement.Application.Contract.ArticleCategoryApp
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string KeyWords { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string CanonicalAddress { get; set; }
    }
}

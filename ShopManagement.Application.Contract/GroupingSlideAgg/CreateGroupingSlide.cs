using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contract.GroupingApp;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.GroupingSlideAgg
{
    public class CreateGroupingSlide 
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessage.maxFileSizeMessage)]
        [FileExtentionLimitation(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = ValidationMessage.ExtentionMessage)]
        public IFormFile Picture { get;  set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string PictureTitle { get;  set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Link { get;  set; }
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.RequiredMessage)]
        public long GroupingId { get;  set; }
        public List<ViewModelGrouping> ModelGroupings{ get; set; }
    }
}

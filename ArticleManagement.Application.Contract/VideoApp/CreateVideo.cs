using ArticleManagement.Application.Contract.VideoCategoryApp;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ArticleManagement.Application.Contract.VideoApp
{
    public class CreateVideo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public IFormFile Videos { get; set; }
        public string Type { get; set; }
        public long VideoCategoryId { get; set; }
        public string Slug { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public List<ViewModelVideoCategory> ModelVideoCategory { get; set; }
    }
}

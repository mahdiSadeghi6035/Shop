using _0_Framework.Domain;
using ArticleManagement.Domain.VideoAgg;
using System.Collections.Generic;

namespace ArticleManagement.Domain.VideoCategoryAgg
{
    public class VideoCategory : DomainBase<long>
    {
        public string Name { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public List<Video> Video { get; private set; }
        public VideoCategory(string name, string slug, string keyWords, string metaDescription)
        {
            Name = name;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Video = new List<Video>();
        }
        public void Edit(string name, string slug, string keyWords, string metaDescription)
        {
            Name = name;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
        }
    }
}

using _0_Framework.Domain;
using ArticleManagement.Domain.VideoCategoryAgg;

namespace ArticleManagement.Domain.VideoAgg
{
    public class Video : DomainBase<long>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Videos { get; private set; }
        public string Type { get; private set; }
        public long VideoCategoryId { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public VideoCategory VideoCategory { get; private set; }

        public Video(string name, string description, string picture, string pictureAlt, string pictureTitle, string videos, string type, long videoCategoryId, string slug, string keyWords, string metaDescription)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Videos = videos;
            Type = type;
            VideoCategoryId = videoCategoryId;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
        }

        public void Edit(string name, string description, string picture, string pictureAlt, string pictureTitle, string videos, string type, long videoCategoryId, string slug, string keyWords, string metaDescription)
        {
            Name = name;
            Description = description;
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            if (!string.IsNullOrWhiteSpace(videos))
                Videos = videos;
            Type = type;
            VideoCategoryId = videoCategoryId;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
        }
    }
}

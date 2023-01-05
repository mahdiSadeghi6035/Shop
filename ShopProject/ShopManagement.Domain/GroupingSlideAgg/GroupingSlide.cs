using _0_Framework.Domain;
using ShopManagement.Domain.GroupingAgg;

namespace ShopManagement.Domain.GroupingSlideAgg
{
    public class GroupingSlide : DomainBase<long>
    {
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Link { get; private set; }
        public long GroupingId{ get; private set; }
        public Grouping Groupings{ get; private set; }
        public bool IsRemoved { get; private set; }

        public GroupingSlide(string picture, string pictureAlt, string pictureTitle, string link, long groupingId)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Link = link;
            GroupingId = groupingId;
            IsRemoved = false;  
        }
        public void Edit(string picture, string pictureAlt, string pictureTitle, string link, long groupingId)
        {
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Link = link;
            GroupingId = groupingId;
        }
        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}

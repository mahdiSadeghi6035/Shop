namespace ShopManagement.Application.Contract.GroupingSlideAgg
{
    public class ViewModelGroupingSlide
    {
        public long Id { get; set; }
        public string GroupingName { get; set; }
        public long GroupinId { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string CreateionDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}

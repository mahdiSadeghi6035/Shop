namespace _01_ShopQuery.Contract.Slide
{
    public class SlideModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Link { get; set; }
        public bool IsRemoved { get; set; }
    }
}

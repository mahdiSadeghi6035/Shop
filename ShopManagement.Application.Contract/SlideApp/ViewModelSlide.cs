namespace ShopManagement.Application.Contract.SlideApp
{
    public class ViewModelSlide
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string CreateionDate { get; set; }
        public bool IsRemoved { get; set; }
    }
}

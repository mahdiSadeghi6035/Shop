namespace ArticleManagement.Application.Contract.VideoApp
{
    public class ViewModelVideo
    {
        public long Id { get; set; }
        public string VideoCategory { get; set; }
        public long VideoCategoryId { get; set; }
        public string Name { get; set; }
        public string CreateionDate { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
    }
}

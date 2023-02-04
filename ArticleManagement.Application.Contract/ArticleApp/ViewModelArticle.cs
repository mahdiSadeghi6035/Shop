namespace ArticleManagement.Application.Contract.ArticleApp
{
    public class ViewModelArticle
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ArticleCategory { get; set; }
        public long ArticleCategoryId { get; set; }
        public string PublishDate { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
    }
}

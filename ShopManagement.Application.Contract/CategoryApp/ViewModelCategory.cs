namespace ShopManagement.Application.Contract.CategoryApp
{
    public class ViewModelCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Description { get; set; }
        public long GroupingId { get; set; }
        public string Grouping { get; set; }
        public string CreateionDate { get; set; }
    }
}

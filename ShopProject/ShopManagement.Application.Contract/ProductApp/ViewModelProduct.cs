namespace ShopManagement.Application.Contract.ProductApp
{
    public class ViewModelProduct
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public long BrandId { get; set; }
        public string BrandeName { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CreationDate { get; set; }
    }
}

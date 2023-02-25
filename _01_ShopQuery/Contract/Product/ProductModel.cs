namespace _01_ShopQuery.Contract.Product
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Specifications { get; set; }
        public long BrandId { get; set; }
        public long CategoryId { get; set; }
        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }
        public string Code { get; set; }
        public double UnitPrice { get; set; }
        public double DiscountPrice { get; set; }
        public double Discount { get; set; }
        public bool Status { get; set; }
        public bool InStock { get; set; }
        public bool HasDiscount { get; set; }
    }
}

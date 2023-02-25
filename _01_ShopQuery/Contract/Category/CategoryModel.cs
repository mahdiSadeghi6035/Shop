using _01_ShopQuery.Contract.Product;
using System.Collections.Generic;

namespace _01_ShopQuery.Contract.Category
{
    public class CategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }
        public long GroupingId { get; set; }
        public List<ProductModel> ProductModel{ get; set; }
    }
}

using _01_ShopQuery.Contract.Category;
using _01_ShopQuery.Contract.Product;
using System.Collections.Generic;

namespace _01_ShopQuery.Contract.GroupingProduct
{
    public class GroupingModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public List<ProductModel> ProductModels{ get; set; }
        public List<CategoryModel> CategoryModel{ get; set; }
    }
}

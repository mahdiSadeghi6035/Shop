using _01_ShopQuery.Contract.Category;
using ShopManagement.Infrastructure.EfCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_ShopQuery.Query
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly ShopContext _shopContext;

        public CategoryQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public IEnumerable<CategoryModel> GetCategory()
        {
            return _shopContext.Categorys.Select(x => new CategoryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}

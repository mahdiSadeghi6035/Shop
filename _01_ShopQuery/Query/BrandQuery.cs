using _01_ShopQuery.Contract.Brand;
using ShopManagement.Infrastructure.EfCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_ShopQuery.Query
{
    public class BrandQuery : IBrandQuery
    {
        private readonly ShopContext _shopContext;

        public BrandQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public IEnumerable<BrandModel> GetBrands()
        {
            return _shopContext.Brands.Select(x => new BrandModel
            {
                Id = x.Id,
                Slug = x.Slug,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}

using _01_ShopQuery.Contract.Slide;
using ShopManagement.Infrastructure.EfCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_ShopQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public IEnumerable<SlideModel> GetSlide()
        {
            return _shopContext.Slides.Where(x => !x.IsRemoved).Select(x => new SlideModel
            {
                Id = x.Id,
                Link = x.Link,
                Picture = x.Picture,
                IsRemoved = x.IsRemoved,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}

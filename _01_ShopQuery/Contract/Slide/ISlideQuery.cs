using System.Collections.Generic;

namespace _01_ShopQuery.Contract.Slide
{
    public interface ISlideQuery
    {
        IEnumerable<SlideModel> GetSlide();
    }
}

using _0_Framework.Domain;
using ShopManagement.Application.Contract.SlideApp;
using System.Collections.Generic;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<long, Slide>
    {
        EditSlide GetEdit(long id);
        List<ViewModelSlide> GetSlides();
    }
}

using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.SlideApp
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        EditSlide GetEdit(long id);
        List<ViewModelSlide> GetSlides();
        OperationResult Remove(long id);
        OperationResult Restore(long id);
    }
}

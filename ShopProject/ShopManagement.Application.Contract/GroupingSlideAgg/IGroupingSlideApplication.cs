using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.GroupingSlideAgg
{
    public interface IGroupingSlideApplication
    {
        OperationResult Create(CreateGroupingSlide command);
        OperationResult Edit(EditGroupingSlide command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditGroupingSlide GetEdit(long id);
        List<ViewModelGroupingSlide> Search(SearchModelGroupingSlide searchModel);
    }
}

using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.GroupingApp
{
    public interface IGroupingApplication
    {
        OperationResult Create(CreateGrouping command);
        OperationResult Edit(EditGrouping command);
        EditGrouping Exists(long id);
        List<ViewModelGrouping> Search(SearchModelGrouping searchModel);
    }
}

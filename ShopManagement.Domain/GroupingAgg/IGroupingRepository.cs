using _0_Framework.Domain;
using ShopManagement.Application.Contract.GroupingApp;
using System.Collections.Generic;

namespace ShopManagement.Domain.GroupingAgg
{
    public interface IGroupingRepository : IRepository<long, Grouping>
    {
        EditGrouping Exists(long id);
        List<ViewModelGrouping> Search(SearchModelGrouping searchModel);
        List<ViewModelGrouping> GetGroupings();
        string GetSlug(long id);
    }
}

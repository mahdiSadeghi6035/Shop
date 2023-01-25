using _0_Framework.Domain;
using ShopManagement.Application.Contract.GroupingSlideAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.GroupingSlideAgg
{
    public interface IGroupingSlideRepository : IRepository<long, GroupingSlide>
    {
        EditGroupingSlide GetEdit(long id);
        List<ViewModelGroupingSlide> Search(SearchModelGroupingSlide searchModel);
        GroupingSlide Get(long id);
    }
}

using System.Collections.Generic;

namespace _01_ShopQuery.Contract.GroupingProduct
{
    public interface IGroupingQuery
    {
        IEnumerable<GroupingModel> GetGroupingWithCategoryProduct();
        IEnumerable<GroupingModel> GetLatestProduct();
    }
}

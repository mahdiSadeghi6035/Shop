using System.Collections.Generic;

namespace _01_ShopQuery.Contract.Category
{
    public interface ICategoryQuery
    {
        IEnumerable<CategoryModel> GetCategory();
    }
}

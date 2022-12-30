using _0_Framework.Domain;
using ShopManagement.Application.Contract.CategoryApp;
using System.Collections.Generic;

namespace ShopManagement.Domain.CategoryAgg
{
    public interface ICategoryRepository : IRepository<long,Category>
    {
        EditCategory Exists(long id);
        List<ViewModelCategory> Search(SearchModelCategory searchModel);
        List<ViewModelCategory> GetCategory();
    }
}

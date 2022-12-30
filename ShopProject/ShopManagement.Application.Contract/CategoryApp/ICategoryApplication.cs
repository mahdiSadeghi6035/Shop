using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.CategoryApp
{
    public interface ICategoryApplication
    {
        OperationResult Create(CreateCategory command);
        OperationResult Edit(EditCategory command);
        EditCategory Exists(long id);
        List<ViewModelCategory> Search(SearchModelCategory searchModel);
        List<ViewModelCategory> GetCategory();
    }
}
